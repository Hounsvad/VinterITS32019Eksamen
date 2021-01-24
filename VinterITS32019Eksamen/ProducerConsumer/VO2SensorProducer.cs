using System.Collections.Concurrent;
using System.Threading;

namespace VinterITS32019Eksamen
{
    class VO2SensorProducer
    {
        private const int SampleTime = 500;
        private readonly ISensor _sensor;
        private readonly BlockingCollection<VO2DataContainer> _vo2DataCollection;

        public VO2SensorProducer(BlockingCollection<VO2DataContainer> vo2DataCollection, ISensor sensor)
        {
            _vo2DataCollection = vo2DataCollection;
            _sensor = sensor;
        }

        public void Run()
        {
            while (true)
            {
                GetOneVO2SensorReading();
                Thread.Sleep(SampleTime); 
            }
        }

        private void GetOneVO2SensorReading()
        {
            VO2DataContainer container = new VO2DataContainer();
            container.VO2Sample = _sensor.VO2Sample();
            _vo2DataCollection.Add(container);
        }
    }
}