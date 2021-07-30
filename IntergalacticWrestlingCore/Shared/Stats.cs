using System;
using System.Collections.Generic;
using System.Text;

namespace IntergalacticWrestlingCore.Shared
{
    public class Stats
    {
        public int Strength { get; set; }
        public int Endurance { get; set; }
        public int Charisma { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }

        public static Stats operator+ (Stats a, Stats b)
        {
            var stats = new Stats();
            stats.Strength = a.Strength + b.Strength;
            stats.Endurance = a.Endurance + b.Endurance;
            stats.Charisma = a.Charisma + b.Charisma;
            stats.Agility = a.Agility + b.Agility;
            stats.Luck = a.Luck + b.Luck;

            return stats;
        }
    }
}
