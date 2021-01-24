using System;

namespace VinterITS32019Eksamen
{
    public class VO2SensorFactory
    {
        public static ISensor CreateVO2Sensor(string vO2SensorType)
        {
            if (vO2SensorType == "random")
            {
                return new RandomSensor();
            }

            throw new ArgumentException("Unknown VO2 Sensor Type" + vO2SensorType);
        }
    }
}