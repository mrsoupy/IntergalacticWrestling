using IntergalacticWrestlingCore.Helpers;
using IntergalacticWrestlingCore.Moves.Base;
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

        private bool Pin { get; set; }

        private WrestlerState winner { get; set; }

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
                Console.WriteLine($"{item.Wrestler.Name} : {item.Wrestler.Species.Name.ToString()} Entering");
            }
            int counter = 1;

            while (MatchState == "Started")
            {
                Console.WriteLine($"Round {counter}");
                var priorityList = Wrestlers.OrderByDescending(x => x.Priority);

                foreach (var wrestler in priorityList)
                {
                    var wrestlerString = $"{wrestler.Wrestler.Name} : {wrestler.Wrestler.Species.Name.ToString()}";
                    var target = Wrestlers.Where(x => x.Team != wrestler.Team).First();
                    var state = wrestler.State;

                    switch (state)
                    {
                        case Enums.State.Standing:
                            ProcessMove(wrestler, target);
                            break;
                        case Enums.State.KnockedDown:
                            if (wrestler.StandUp())
                            {
                                Console.WriteLine($"{wrestlerString} has stood back up");
                            }
                            break;
                        case Enums.State.Gassed:
                            Console.WriteLine($"{wrestlerString} is gassed and recovering");
                            wrestler.Recover();
                            break;
                        case Enums.State.Pinned:
                            Console.WriteLine($"{wrestlerString} is being pinned!");
                            int pinCount = wrestler.Pin();
                            if(pinCount == 3)
                            {
                                winner = wrestler.InteractingWrestler;
                                MatchState = "Finished";
                            }
                            else
                            {
                                Console.WriteLine($"{wrestlerString} kicked out at {pinCount}");
                            }
                            break;

                    }


                    
                }

                System.Threading.Thread.Sleep(2000);

                counter++;

                if (Wrestlers.Any(x => x.Health < 1)){
                    MatchState = "Finished";
                    winner = Wrestlers.Where(x => x.Health > 0).First();
                }

            }

            Console.WriteLine($"{winner.Wrestler.Name} has got the 3 count");
        }

        private void ProcessMove(WrestlerState wrestler, WrestlerState target, Move reversalMove = null)
        {
            var move = SelectMove(wrestler, target);
            if (reversalMove != null)
            {
                move = reversalMove;
            }
            if(move != null)
            {
                if (wrestler.Hit(move, target))
                {
                    if (target.Reversal() && (target.State != Enums.State.Gassed))
                    {
                        var reversal = SelectMove(target, wrestler);
                        if (reversal != null) {
                            Console.WriteLine($"{target.Wrestler.Name} has reversed {move.Name} with {reversal.Name}");
                            System.Threading.Thread.Sleep(2000);
                            ProcessMove(target, wrestler, reversal);
                        }
                        else
                        {
                            Console.WriteLine($"{target.Wrestler.Name} has dodged {move.Name}");
                            target.State = Enums.State.Gassed;
                        }
                    }
                    else
                    {
                        int damage = wrestler.Damage(move);

                        target.ApplyDamage(damage);
                        Console.WriteLine($"{wrestler.Wrestler.Name} with {move.Name} for {damage} damage");
                        if (move.CanKnockdown)
                        {
                            if (target.Knockdown(move))
                            {
                                Console.WriteLine($"{wrestler.Wrestler.Name} has knocked down {target.Wrestler.Name} with {move.Name}");
                            }
                        }

                    }
                }
            }
            else
            {
                wrestler.State = Enums.State.Gassed;
            }
        }

        private Move SelectMove(WrestlerState wrestler, WrestlerState target) {
            var moves = wrestler.Wrestler.Moves.Where(x => x.EnergyUse < wrestler.Energy && x.AcceptedStates.Contains(wrestler.State) && x.OpponentStates.Contains(target.State)).ToList();
            if (moves.Count() > 0)
            {
                int selectedMoveIndex = (int)RandomHelpers.GetRoll(moves.Count(), 1) - 1;
                var selectedMove = moves[selectedMoveIndex];
                return selectedMove;
            }
            return null;
        }

    }
}
