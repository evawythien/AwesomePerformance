using System;
using System.Linq;

namespace AwesomePerformance
{
    public class ArrayPool : IPool
    {
        private ItemPool[] pool;

        public ArrayPool(int[] pool)
        {
            this.pool = pool.GroupBy(n => n).Select(g => new ItemPool(g.Key, g.Count())).ToArray();
        }

        public bool Contains(int[] sequence)
        {
            foreach (var item in sequence)
            {
                var element = pool.FirstOrDefault(n => n.Number == item);
                if (element == null)
                    return false;

                if (element.Repetitions <= 0)
                    return false;

                element.Repetitions = element.Repetitions - 1;
            }

            return true;
        }
    }
}
