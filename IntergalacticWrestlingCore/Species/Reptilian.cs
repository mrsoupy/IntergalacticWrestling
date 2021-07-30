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
    public class Reptilian : ISpecies
    {
        public SpeciesType Name => SpeciesType.Reptilian;

        public string Description => "Scaly";

        public Stats SpeciesStats
        {
            get => new Stats
            {
                Strength = 60,
                Endurance = 100,
                Charisma = 10,
                Agility = 70,
                Luck = 40
            };
        }
        public List<Perk> SpeciesPerks { get => new List<Perk>(); }
        public List<Move> SpeciesMoves { get => new List<Move>(); }

        public int Weight { get => 100; }

    }
}
