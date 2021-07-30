using System;
using System.Collections.Generic;
using IntergalacticWrestlingCore.Wrestler;
using System.Text;
using IntergalacticWrestlingCore.Wrestler.Base;
using IntergalacticWrestlingCore.Helpers;

namespace IntergalacticWrestlingCore.Roster
{
    public class Roster
    {
        public List<Wrestler.Base.Wrestler> Wrestlers { get; set; }

        public void CreateNewRoster(int count)
        {
            Wrestlers = new List<Wrestler.Base.Wrestler>();

            for (int i = 0; i < count; i++)
            {
                var wrestler = new Wrestler.Base.Wrestler();
                wrestler.Species = Helpers.RosterHelpers.GetRandomSpecies();

                //To do: create random name generator
                wrestler.Name =$"Wrestler {i.ToString()}";

                wrestler.Stats = RosterHelpers.GetRandomStats(10) + wrestler.Species.SpeciesStats;
                wrestler.Moves = RosterHelpers.GetRandomMoveList(wrestler.Species.Name);

                Wrestlers.Add(wrestler);
            }
        }
    }
}
