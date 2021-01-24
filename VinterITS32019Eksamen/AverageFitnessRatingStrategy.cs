using System;
using System.Collections.Generic;
using System.Linq;

namespace VinterITS32019Eksamen
{
    public class AverageFitnessRatingStrategy:IFitnessRatingCalculatorStrategy
    {
        private List<int> _vO2SampleList = new List<int>();
        private int weight = 80;

        public double CalculateFitnessRating() //List<int> _vO2SampleList, int weight
        {
            //try
            //{
                double avgFitnessRating = _vO2SampleList.Sum() / _vO2SampleList.Count / weight;
                return avgFitnessRating;
            //}
            //catch (DivideByZeroException)
            //{
                
            //}

            //return 0;
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
            Console.WriteLine("Average Fitness Rating: " + fitnessRating);
        }
    }
}