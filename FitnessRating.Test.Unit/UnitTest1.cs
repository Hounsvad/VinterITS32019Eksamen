using NUnit.Framework;
using System.Collections.Generic;
using System;
using VinterITS32019Eksamen;

namespace FitnessRating.Test.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(47, 3700, 3766, 4000, 3689)]
        public void Test_average_rating(double exp,params int []values)
        {
            AverageFitnessRatingStrategy average = new AverageFitnessRatingStrategy();

            for (int i = 0; i < values.Length; i++)
            {
                average.AddToList(values[i]);
            }
            Assert.That(exp,Is.EqualTo(Math.Round(average.CalculateFitnessRating(),2)));
        }

        [TestCase(63, 5116, 3700, 3766, 4000, 3689)]
        public void Test_maximum_rating(double exp, params int[] values)
        {
            MaxFitnessRatingStrategy maximum = new MaxFitnessRatingStrategy();

            for (int i = 0; i < values.Length; i++)
            {
                maximum.AddToList(values[i]);
            }

            Assert.That(exp, Is.EqualTo(Math.Round(maximum.CalculateFitnessRating(), 2)));
        }
    }
}