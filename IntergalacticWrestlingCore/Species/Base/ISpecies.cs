using IntergalacticWrestlingCore.Moves.Base;
using IntergalacticWrestlingCore.Perks.Base;
using IntergalacticWrestlingCore.Shared;
using IntergalacticWrestlingCore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntergalacticWrestlingCore.Species.Base
{
    public interface ISpecies
    {
        SpeciesType Name { get;}

        string Description { get;}

        Stats SpeciesStats { get; }

        List<Perk> SpeciesPerks { get; }

        int Weight { get; }

        //public List<BaseSpecies> SpeciesList {  
        //    get {
        //        var speciesList = new List<BaseSpecies>();

        //        speciesList.Add(new BaseSpecies("Skeleton", "They're spooky, and scary"));
        //        speciesList.Add(new BaseSpecies("Dolphi", "Roving packs of space dolphins"));
        //        speciesList.Add(new BaseSpecies("Reptilian", "Scaly"));
        //        speciesList.Add(new BaseSpecies("Ferno", "Small, ugly and here for the money"));
        //        speciesList.Add(new BaseSpecies("Octopodi", "An ancient cephalopod race awakened by the call to the ring"));
        //        speciesList.Add(new BaseSpecies("Human", "Creators of the wrestling"));


        //        return speciesList;
        //    } 
        // }
    }
}
