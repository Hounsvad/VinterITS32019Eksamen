using System;

namespace VinterITS32019Eksamen
{
    public class RandomSensor:ISensor
    {
        private readonly Random _random = new Random();

        public int VO2Sample()
        {
            //Produce random number
            return _random.Next(2500, 6000);
        }

    }
}