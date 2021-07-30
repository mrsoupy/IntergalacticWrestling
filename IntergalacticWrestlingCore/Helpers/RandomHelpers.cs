using System;
using System.Collections.Generic;
using System.Text;

namespace IntergalacticWrestlingCore.Helpers
{
    public static class RandomHelpers
    {
        public static double GetRoll(int max, double multiplier)
        {
            var rand = new Random();
            return rand.Next(1, max) * multiplier;
        }
    }
}
