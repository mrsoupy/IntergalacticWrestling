using IntergalacticWrestlingCore.Moves.Base;
using IntergalacticWrestlingCore.Perks.Base;
using IntergalacticWrestlingCore.Shared;
using IntergalacticWrestlingCore.Species.Base;
using IntergalacticWrestlingCore.Species.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntergalacticWrestlingCore.Wrestler.Base
{
    public class Wrestler
    {
        public string Name { get; set; }
        public ISpecies Species { get; set; }
        public Stats Stats { get; set; }

        public List<Perk> Perks { get; set; }

        public List<Limb> Limbs { get; set; }

        public List<Equipment> Items { get; set; }

        public List<Move> Moves { get; set; }
    }
}
