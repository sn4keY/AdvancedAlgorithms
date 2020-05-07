using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Utilities
{
    class Utilities
    {
        private static Random rnd = new Random();

        public static int GetRandomInt(int from, int to)
        {
            return rnd.Next(from, to);
        }
    }
}
