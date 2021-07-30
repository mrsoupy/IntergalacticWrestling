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
    public class Ferno : ISpecies
    {
        public SpeciesType Name => SpeciesType.Ferno;

        public string Description => "Small, ugly and here for the money";

        public Stats SpeciesStats
        {
            get => new Stats
            {
                Strength = 10,
                Endurance = 40,
                Charisma = 50,
                Agility = 60,
                Luck = 90
            };
        }
        public List<Perk> SpeciesPerks { get => new List<Perk>(); }
        public List<Move> SpeciesMoves { get => new List<Move>(); }

        public int Weight { get => 100; }
    }
}
