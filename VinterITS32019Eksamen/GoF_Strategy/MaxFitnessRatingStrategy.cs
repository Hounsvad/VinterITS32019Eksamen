using System;
using System.Collections.Generic;
using System.Linq;

namespace VinterITS32019Eksamen
{
    public class MaxFitnessRatingStrategy:IFitnessRatingCalculatorStrategy
    {
        private int weight = 80;
        private List<int> _vO2SampleList = new List<int>();

        public double CalculateFitnessRating()
        {
            int maxVO2Sample = _vO2SampleList.Max();
            double maxFitnessRating = maxVO2Sample / weight;
            return maxFitnessRating;
        }
        public void AddToList(int sample)
        {
            _vO2SampleList.Add(sample);
        }

        public void ClearList()
        {
            _vO2SampleList.Clear();
        }

        public void Print(double fitnessRating)
        {
            Console.WriteLine("Max Fitness Rating: " + fitnessRating);
        }
    }
}