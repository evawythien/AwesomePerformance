using System.Collections.Generic;
using System.Linq;

namespace AwesomePerformance
{
    public class HashPool : IPool
    {
        private HashSet<int> pool;

        public HashPool(int[] pool)
        {
            this.pool = new HashSet<int>(pool);
        }

        public bool Contains(int[] sequence)
        {
            return sequence.All(d => pool.Contains(d));
        }
    }
}
