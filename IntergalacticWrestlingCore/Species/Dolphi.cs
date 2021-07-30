using IntergalacticWrestlingCore.Moves.Base;
using IntergalacticWrestlingCore.Perks.Base;
using IntergalacticWrestlingCore.Shared;
using IntergalacticWrestlingCore.Shared.Enums;
using IntergalacticWrestlingCore.Species.Base;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace IntergalacticWrestlingCore.Species
{
    public class Dolphi : ISpecies
    {
        public SpeciesType Name => SpeciesType.Dolphi;
        public string Description { get => "Roving packs of space dolphins"; }
        public Stats SpeciesStats { get => new Stats
        {
            Strength = 60,
            Endurance = 80,
            Charisma = 50,
            Agility = 100,
            Luck = 40
        };
        }
        public List<Perk> SpeciesPerks { get => new List<Perk>(); }
        public List<Move> SpeciesMoves { get => new List<Move>(); }

        public int Weight { get => 100; }
    }
}
