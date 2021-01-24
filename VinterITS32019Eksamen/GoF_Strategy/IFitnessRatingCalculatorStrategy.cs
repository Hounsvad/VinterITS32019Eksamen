using System.Collections.Generic;

namespace VinterITS32019Eksamen
{
    public interface IFitnessRatingCalculatorStrategy
    {
        double CalculateFitnessRating();

        public void AddToList(int sample);
        public void ClearList();

        public void Print(double fitnessRating);
    }
}