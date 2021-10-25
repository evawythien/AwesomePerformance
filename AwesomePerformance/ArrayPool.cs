using System;
using System.Linq;

namespace AwesomePerformance
{
    public class ArrayPool : IPool
    {
        private int[] pool;

        public ArrayPool(int[] pool)
        {
            this.pool = pool;
        }

        public bool Contains(int[] sequence)
        {
            return sequence.All(d => pool.Contains(d));
        }
    }
}
