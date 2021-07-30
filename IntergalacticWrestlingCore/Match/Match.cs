using IntergalacticWrestlingCore.Helpers;
using IntergalacticWrestlingCore.Wrestler.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IntergalacticWrestlingCore.Match
{
    public class Match
    {
        public List<WrestlerState> Wrestlers { get; set; }

        public StringBuilder MatchLog { get; set; }

        public string MatchState { get; set; }

        public Match(List<WrestlerState> wrestlers)
        {
            this.MatchLog = new StringBuilder();
            this.Wrestlers = wrestlers;
        }

        public void StartMatch()
        {
            MatchState = "Started";
            var teams = Wrestlers.GroupBy(x => x.Team).Select(x => x.Key).ToArray();
            Console.WriteLine($"Teams are {String.Join(", ", teams)}");

            foreach (var item in Wrestlers)
            {
                Console.WriteLine($"{item.Wrestler.Name} : {item.Wrestler.Species.ToString()} Entering");
            }
            int counter = 1;

            while (MatchState == "Started")
            {
                Console.WriteLine($"Round {counter}");
                var priorityList = Wrestlers.OrderByDescending(x => x.Priority);

                foreach (var wrestler in priorityList)
                {
                    Console.WriteLine($"{wrestler.Wrestler.Name} has priority");
                    if (wrestler.State == Enums.State.Gassed)
                    {
                        Console.WriteLine($"{wrestler.Wrestler.Name} is gassed and recovering");
                        wrestler.Recover();
                        wrestler.State = Enums.State.Standing;
                    }


                    

                    if (wrestler.State != Enums.State.KnockedDown)
                    {

                        var target = Wrestlers.Where(x => x.Team != wrestler.Team).First();
                        
                        Console.WriteLine($"{wrestler.Wrestler.Name} is choosing a move");
                        var move = wrestler.Wrestler.Moves.Where(x => x.EnergyUse < wrestler.Energy && x.AcceptedStates.Contains(wrestler.State) && x.OpponentStates.Contains(target.State)).ToList();

                        if (move.Count() > 0)
                        {
                            int selectedMoveIndex = (int)RandomHelpers.GetRoll(move.Count(), 1) - 1;
                            var selectedMove = move[selectedMoveIndex];
                            Console.WriteLine($"{selectedMove.Name} target is {target.Wrestler.Name} ");

                            Console.WriteLine($"{wrestler.Wrestler.Name} has chosen {selectedMove.Name}");
                            
                            if (wrestler.Hit(selectedMove))
                            {
                                Console.WriteLine($"{wrestler.Wrestler.Name} hit {selectedMove.Name} on {target.Wrestler.Name}");
                                Console.WriteLine("Applying damage");
                                target.ApplyDamage(wrestler.Damage(selectedMove));
                                target.Knockdown(selectedMove);
                                if (target.Health <= 0)
                                {
                                    Console.WriteLine($"{wrestler.Wrestler.Name} has won");
                                    MatchState = "Finished";
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{wrestler.Wrestler.Name} missed {selectedMove.Name} on {target.Wrestler.Name}. What a jobber!");
                            }

                        }


                        else
                        {
                            wrestler.State = Enums.State.Gassed;
                            Console.WriteLine($"{wrestler.Wrestler.Name} is gassed");
                        }
                    }
                    else
                    {
                        wrestler.Recover();
                    }

                    System.Threading.Thread.Sleep(2000);
                }





                counter++;


            }
        }

        private void SetState(WrestlerState wrestler)
        {
            var w = Wrestlers.Where(x => x.Wrestler.Name == wrestler.Wrestler.Name).First();
            w = wrestler;
        }

    }
}
