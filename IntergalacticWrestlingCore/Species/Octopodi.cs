using IntergalacticWrestlingCore.Moves.Base;
using IntergalacticWrestlingCore.Perks.Base;
using IntergalacticWrestlingCore.Shared;
using IntergalacticWrestlingCore.Shared.Enums;
using IntergalacticWrestlingCore.Species.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntergalacticWrestlingCore.Species
{
    public class Octopodi : ISpecies
    {
        public SpeciesType Name => SpeciesType.Octopodi;

        public string Description => "An ancient cephalopod race awakened by the call to the ring";

        public Stats SpeciesStats
        {
            get => new Stats
            {
                Strength = 80,
                Endurance = 30,
                Charisma = 30,
                Agility = 100,
                Luck = 50
            };
        }
        public List<Perk> SpeciesPerks { get => new List<Perk>(); }
        public List<Move> SpeciesMoves { get => new List<Move>(); }

        public int Weight { get => 100; }
    }
}
