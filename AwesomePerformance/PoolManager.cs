using System;
using System.Collections.Generic;
using System.Linq;

namespace AwesomePerformance
{
    public class PoolManager
    {
        public static bool Contains(HashSet<int> pool, int[] sequence)
        {
            return sequence.All(d => pool.Contains(d));
        }

        public static bool Contains(int[] pool, int[] sequence)
        {
            return sequence.All(d => pool.Contains(d));
        }
    }
}
