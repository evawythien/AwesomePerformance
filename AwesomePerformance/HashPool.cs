using System.Collections.Generic;
using System.Linq;

namespace AwesomePerformance
{
    public class HashPool : IPool
    {
        private Dictionary<int, int> pool;

        public HashPool(int[] pool)
        {
            this.pool = pool.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
        }

        public bool Contains(int[] sequence)
        {
            foreach (var item in sequence)
            {
                if (!pool.TryGetValue(item, out int repetitions))
                    return false;

                if (repetitions <= 0)
                    return false;

                repetitions--;

                pool[item] = repetitions;
            }

            return true;
        }
    }
}
