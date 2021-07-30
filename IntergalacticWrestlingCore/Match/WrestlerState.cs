using IntergalacticWrestlingCore.Helpers;
using IntergalacticWrestlingCore.Match.Enums;
using IntergalacticWrestlingCore.Moves.Base;
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
            this.Energy = (int)(RandomHelpers.GetRoll(Wrestler.Stats.Agility, 0.5) + RandomHelpers.GetRoll(Wrestler.Stats.Endurance, 1) + RandomHelpers.GetRoll(Wrestler.Stats.Luck, 0.1));
            this.BaseEnergy = Energy;
            this.BaseHealth = Health;
            this.Team = team;

        }
        public Wrestler.Base.Wrestler Wrestler { get; set; }

        private int BaseEnergy {get; set;}

        private int BaseHealth { get; set; }

        public State State { get; set; }

        public int Health { get; set; }

        public int Energy { get; set; }

        public double Priority { get {
                return (RandomHelpers.GetRoll(Wrestler.Stats.Agility, 0.7) + RandomHelpers.GetRoll(Wrestler.Stats.Luck, 0.3));
            } 
        }

        public bool Hit(Move move)
        {
            Energy-= move.EnergyUse;
            return move.HitThreshold < (int)(RandomHelpers.GetRoll(Wrestler.Stats.Agility,1) + RandomHelpers.GetRoll(Wrestler.Stats.Luck, 0.5));
        }

        public void Knockdown(Move move)
        {
            if(move.KnockdownThreshold > (int)(RandomHelpers.GetRoll(Wrestler.Stats.Strength, 1) + RandomHelpers.GetRoll(Wrestler.Stats.Luck, 0.5) - ((Wrestler.Stats.Endurance * 3) - Health)))
            {
                State = State.KnockedDown;
            }
        }

        public int Damage(Move move)
        {
            return move.Damage + (int)(RandomHelpers.GetRoll(Wrestler.Stats.Strength, 0.1));
        }

        public void ApplyDamage(int dmg)
        {
            Health -= dmg;
        }

        public void Recover()
        {
            Energy += (int)(Wrestler.Stats.Endurance * 0.1);

            if(State == State.KnockedDown)
            {
                State = Energy > (int)(RandomHelpers.GetRoll(Wrestler.Stats.Endurance,1)) ? State.Standing : State.KnockedDown;
            }
        }

        public string Team { get; set; }
    }
}
