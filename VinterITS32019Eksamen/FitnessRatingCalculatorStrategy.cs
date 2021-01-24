using System.Collections.Generic;

namespace VinterITS32019Eksamen
{
    public class FitnessRatingCalculatorStrategy
    {
        public IFitnessRatingCalculatorStrategy _fitnessRatingCalculatorStrategy;
        private List<int> _vO2SampleList = new List<int>();
        private int weight = 80;

        public void AddToList(int sample)
        {
            _vO2SampleList.Add(sample);
        }

        public void ClearList()
        {
            _vO2SampleList.Clear();
        }

        //public double GetFitnessRating()
        //{
        //    var rate=_fitnessRatingCalculatorStrategy.CalculateFitnessRating(_vO2SampleList, weight);
        //    return rate;
        //}
    }
}