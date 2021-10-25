using NUnit.Framework;
using System;
using System.Diagnostics;

namespace AwesomePerformance.Test
{
    public class HashPoolTests
    {
        [Test]
        public void When_PoolNotContainsSequence_False()
        {
            // Arrange
            IPool pool = new HashPool(new int[] { 1, 4, 45, 23, 23, 0, 1245, 2321, 5, 11, 0, 78 });
            int[] sequence = { 4, 5, 1, 43, 21 };
            int[] sequenceWithRepetitions = { 4, 4, 4, 4, 5, 1, 43, 21 };

            // Act
            bool contains = pool.Contains(sequence);
            bool containsWithRepetitions = pool.Contains(sequenceWithRepetitions);

            // Assert
            Assert.IsFalse(contains, "No repetitions");
            Assert.IsFalse(containsWithRepetitions, "With repetitions");
        }

        [Test]
        public void When_PoolContainsSequence_True()
        {
            // Arrange
            IPool pool = new HashPool(new int[] { 1, 4, 45, 23, 23, 0, 1245, 2321, 5, 11, 0, 78 });
            int[] sequence = { 4, 5, 1, 45, 23 };
            int[] sequenceWithRepetitions = { 4, 4, 4, 4, 5, 1, 45, 23 };

            // Act
            bool contains = pool.Contains(sequence);
            bool containsWithRepetitions = pool.Contains(sequenceWithRepetitions);

            // Assert
            Assert.IsTrue(contains, "No repetitions");
            Assert.IsTrue(containsWithRepetitions, "With repetitions");
        }

        [Test]
        public void When_PoolWithRepetitionsNotContainsSequence_False()
        {
            // Arrange
            IPool pool = new HashPool(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 45, 23, 23, 0, 1245, 2321, 5, 11, 0, 78 });
            int[] sequence = { 4, 5, 1, 43, 21 };
            int[] sequenceWithRepetitions = { 4, 4, 4, 4, 5, 1, 43, 21 };

            // Act
            bool contains = pool.Contains(sequence);
            bool containsWithRepetitions = pool.Contains(sequenceWithRepetitions);

            // Assert
            Assert.IsFalse(contains, "No repetitions");
            Assert.IsFalse(containsWithRepetitions, "With repetitions");
        }

        [Test]
        public void When_PoolWithRepetitionsContainsSequence_True()
        {
            // Arrange
            IPool pool = new HashPool(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 45, 23, 23, 0, 1245, 2321, 5, 11, 0, 78 });
            int[] sequence = { 4, 5, 1, 45, 23 };
            int[] sequenceWithRepetitions = { 4, 4, 4, 4, 5, 1, 45, 23 };

            // Act
            bool contains = pool.Contains(sequence);
            bool containsWithRepetitions = pool.Contains(sequenceWithRepetitions);

            // Assert
            Assert.IsTrue(contains, "No repetitions");
            Assert.IsTrue(containsWithRepetitions, "With repetitions");
        }

        [Test]
        public void When_PoolIsHugeResponseTime_Under100ms()
        {
            Stopwatch sw = new Stopwatch();

            // Arrange
            IPool pool = new HashPool(GenerateNumbers(100000, 1));
            int[] sequence = GenerateNumbers(100000, 2);

            sw.Start();

            // Act
            for (int i = 0; i < 100000; i++)
            {
                bool contains = pool.Contains(sequence);
            }

            sw.Stop();

            // Assert
            Assert.LessOrEqual(sw.ElapsedMilliseconds, 100, "Should be less than 100 ms");
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