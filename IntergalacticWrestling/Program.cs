using System;
using System.Collections.Generic;
using IntergalacticWrestlingCore;
using IntergalacticWrestlingCore.Match;
using IntergalacticWrestlingCore.Roster;

namespace IntergalacticWrestling
{
    class Program
    {
        static void Main(string[] args)
        {
            var roster = new Roster();

            roster.CreateNewRoster(10);

            var wrestler1 = new WrestlerState(roster.Wrestlers[3], "Knuckleheads");
            var wrestler2 = new WrestlerState(roster.Wrestlers[7], "Bum willies");

            var wrestlers = new List<WrestlerState>();
            wrestlers.Add(wrestler1);
            wrestlers.Add(wrestler2);


            var match = new Match(wrestlers);
            match.StartMatch();
            Console.WriteLine(match.MatchLog.ToString());
            Console.ReadLine();
        }
    }
}
