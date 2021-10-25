using NUnit.Framework;
using System;

namespace AwesomePerformance.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_PoolNotContainsSequence_False()
        {
            int[] pool = { 1, 4, 45, 23, 23, 0, 1245, 2321, 5, 11, 0, 78 };
            int[] sequence = { 4, 4, 5, 1, 43, 21 };

            bool contains = PoolManager.Contains(pool, sequence);
            Assert.IsFalse(contains);
        }

        [Test]
        public void When_PoolContainsSequence_True()
        {
            int[] pool = { 1, 4, 45, 23, 23, 0, 1245, 2321, 5, 11, 0, 78 };
            int[] sequence = { 4, 4, 5, 1, 45, 23 };

            bool contains = PoolManager.Contains(pool, sequence);
            Assert.IsTrue(contains);
        }

        public static int[] GenerateNumbers(int size, int? seed = null)
        {
            int[] number = new int[size];
            Random random = seed != null ? new Random(seed.Value) : new Random();

            for (int i = 0; i < number.Length; i++)
            {
                number[i] = random.Next(0, int.MaxValue);
            }

            return number;
        }
    }
}