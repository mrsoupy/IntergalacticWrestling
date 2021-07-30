using IntergalacticWrestlingCore.Match.Enums;
using IntergalacticWrestlingCore.Moves.Enums;
using IntergalacticWrestlingCore.Shared.Enums;
using IntergalacticWrestlingCore.Species.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntergalacticWrestlingCore.Moves.Base
{
    public class Move
    {
        public string Name { get; set; }
        public int EnergyUse { get; set; }
        public int Damage { get; set; }
        public int HitThreshold { get; set; }
        public State[] AcceptedStates { get; set; }
        public State[] OpponentStates { get; set; }

        public State? ChangeState { get; set; }
        public State? OpponentChangeState { get; set; }
        public int MinimumRound { get; set; }
        public MoveType MoveType { get; set; }
        public int KnockdownResistThreshold { get; set; }
        public bool CanKnockdown { get; set; }
        public List<SpeciesType> SpeciesNotUsableBy { get; set; }


        
    }
}
