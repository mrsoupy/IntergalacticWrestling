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
    public class Human : ISpecies
    {
        public SpeciesType Name => SpeciesType.Human;

        public string Description => "Creators of the wrestling";

        public Stats SpeciesStats
        {
            get => new Stats
            {
                Strength = 50,
                Endurance = 50,
                Charisma = 100,
                Agility = 50,
                Luck = 50
            };
        }
        public List<Perk> SpeciesPerks { get => new List<Perk>(); }
        public List<Move> SpeciesMoves { get => new List<Move>(); }

        public int Weight { get => 100; }
    }
}
