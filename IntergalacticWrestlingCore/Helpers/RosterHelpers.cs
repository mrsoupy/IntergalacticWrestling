﻿using IntergalacticWrestlingCore.Match.Enums;
using IntergalacticWrestlingCore.Moves.Base;
using IntergalacticWrestlingCore.Shared;
using IntergalacticWrestlingCore.Shared.Enums;
using IntergalacticWrestlingCore.Species;
using IntergalacticWrestlingCore.Species.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntergalacticWrestlingCore.Helpers
{
    public static class RosterHelpers
    {
        public static ISpecies GetRandomSpecies()
        {
            switch(new Random().Next(0,4))
            {
                case 0:
                    return new Dolphi();
                case 1:
                    return new Ferno();
                case 2:
                    return new Human();
                case 3:
                    return new Octopodi();
                case 4:
                    return new Reptilian();
            }
            return new Human();
        }

        public static Stats GetRandomStats(int max)
        {
            var rand = new Random();
            var stats = new Stats{
                Strength = rand.Next(0, max),
                Endurance = rand.Next(0, max),
                Agility = rand.Next(0, max),
                Charisma = rand.Next(0, max),
                Luck = rand.Next(0, max)
            };

            return stats;
        }

        public static List<Move> GetRandomMoveList(SpeciesType species)
        {
        
                var moveList = new List<Move>();
                moveList.Add(new Move { Name = "Clothesline", EnergyUse = 10, Damage = 10, HitThreshold = 50, KnockdownThreshold = 60, AcceptedStates = new[] { State.Standing }, OpponentStates = new[] { State.Standing , State.Gassed } });
                moveList.Add(new Move { Name = "Chop", EnergyUse = 3, Damage = 5, HitThreshold = 10, AcceptedStates = new[] { State.Standing }, OpponentStates = new[] { State.Standing, State.Gassed } });
                moveList.Add(new Move { Name = "Canadian Destroyer", EnergyUse = 30, Damage = 200, KnockdownThreshold = 999, HitThreshold = 70, AcceptedStates = new[] { State.Standing }, OpponentStates = new[] { State.Standing, State.Gassed } });
                moveList.Add(new Move { Name = "Suplex", EnergyUse = 20, Damage = 50, HitThreshold = 50, KnockdownThreshold = 999, AcceptedStates = new[] { State.Standing }, OpponentStates = new[] { State.Standing, State.Gassed } });
            moveList.Add(new Move { Name = "Stomp", EnergyUse = 3, Damage = 5, HitThreshold = 50, KnockdownThreshold = 999, AcceptedStates = new[] { State.Standing }, OpponentStates = new[] { State.KnockedDown } });
            moveList.Add(new Move { Name = "Low blow", EnergyUse = 10, Damage = 50, HitThreshold = 50, AcceptedStates = new[] { State.Standing }, OpponentStates = new[] { State.Standing, State.Gassed } });

            return moveList;
            
        }
    }
    
}
