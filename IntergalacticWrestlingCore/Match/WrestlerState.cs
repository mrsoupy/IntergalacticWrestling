using IntergalacticWrestlingCore.Helpers;
using IntergalacticWrestlingCore.Match.Enums;
using IntergalacticWrestlingCore.Moves.Base;
using IntergalacticWrestlingCore.Wrestler.Base;
using System;
using System.Collections.Generic;
using System.Text;


namespace IntergalacticWrestlingCore.Match
{
    public class WrestlerState
    {
        public WrestlerState(Wrestler.Base.Wrestler wrestler, string team)
        {
            this.State = State.Standing;
            this.Wrestler = wrestler;
            this.Health = wrestler.Stats.Endurance * 3;
            this.Energy = wrestler.Stats.Agility;
            this.BaseEnergy = Energy;
            this.BaseHealth = Health;
            this.Team = team;

        }
        public Wrestler.Base.Wrestler Wrestler { get; set; }

        public WrestlerState InteractingWrestler { get; set; }

        private int BaseEnergy { get; set; }

        private int BaseHealth { get; set; }

        public State State { get; set; }

        public int Health { get; set; }

        public int Energy { get; set; }

        private int DownCounter { get; set; }

        public double Priority
        {
            get
            {
                return (RandomHelpers.GetRoll(Wrestler.Stats.Agility, 0.7) + RandomHelpers.GetRoll(Wrestler.Stats.Luck, 0.3) - (State == State.Gassed ? 20 : 0));
            }
        }

        private int recoverThreshold
        {

            get
            {
                return 130 - Wrestler.Stats.Endurance;
            }
        }

        private int reversalThreshold
        {
            get
            {
                return 130 - Wrestler.Stats.Agility;
            }
        }

        public bool Hit(Move move, WrestlerState target = null)
        {
   
            Energy -= move.EnergyUse;
            target.InteractingWrestler = this;
            if (Gassed())
            {
                State = State.Gassed;
            }
            bool hit = move.HitThreshold < (int)(RandomHelpers.GetRoll(Wrestler.Stats.Agility, 1) + RandomHelpers.GetRoll(Wrestler.Stats.Luck, 0.5));
            if (hit)
            {
                if (move.ChangeState != null)
                {
                    State = move.ChangeState.Value;
                }
                if(move.OpponentChangeState != null)
                {
                    target.State = move.OpponentChangeState.Value;
                }
            }
            return hit;
        }

        public bool Knockdown(Move move)
        {
            DownCounter = 0;
            if (move.KnockdownResistThreshold > (int)(RandomHelpers.GetRoll(Wrestler.Stats.Strength, 1)) - (BaseHealth - Health))
            {
                State = State.KnockedDown;
            }

            return State == State.KnockedDown;
        }

        public int Damage(Move move)
        {
            return move.Damage + (int)(RandomHelpers.GetRoll(Wrestler.Stats.Strength, 0.1));
        }

        public void ApplyDamage(int dmg)
        {
            Health -= dmg;
        }

        public bool Reversal()
        {
            return reversalThreshold < (int)(RandomHelpers.GetRoll(Wrestler.Stats.Agility, 1) + RandomHelpers.GetRoll(Wrestler.Stats.Luck, 0.5));
        }

        public bool Recover()
        {
            Energy += (int)(Wrestler.Stats.Endurance * 0.1);

            if (State == State.Gassed)
            {
                State = Gassed() ? State.Gassed : State.Standing;
            }

            return State == State.Standing;
        }

        public int Pin()
        {
            int pinCount = 0;
            bool endPin = false;
            while(!endPin)
            {
                pinCount++;
                if ((BaseHealth - Health) + (int)(RandomHelpers.GetRoll(InteractingWrestler.Wrestler.Stats.Strength, 1)) < (int)(RandomHelpers.GetRoll(Wrestler.Stats.Strength, 2) + RandomHelpers.GetRoll(Wrestler.Stats.Agility, 1) + RandomHelpers.GetRoll(Wrestler.Stats.Luck, pinCount/2)))
                {
                    State = State.KnockedDown;
                    InteractingWrestler.State = State.Standing;

                    endPin = true;
                }
                if (!endPin)
                {
                    if (pinCount == 3)
                    {
                        endPin = true;
                    }
                }
            }
            return pinCount;
        }

        public bool StandUp()
        {
            if (State == State.KnockedDown)
            {
                State = recoverThreshold < (int)(RandomHelpers.GetRoll(Wrestler.Stats.Endurance, 1.1) + RandomHelpers.GetRoll(Wrestler.Stats.Strength, 1.1) + RandomHelpers.GetRoll(Wrestler.Stats.Luck, DownCounter)) - (BaseEnergy - Energy) ? State.Standing : State.KnockedDown;
                DownCounter++;
            }
            return State == State.Standing;
        }

        private bool Gassed()
        {
            return Energy < 1;
        }


        public string Team { get; set; }
    }
}

