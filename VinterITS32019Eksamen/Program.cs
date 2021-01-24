using System;
using System.Collections.Concurrent;
using System.Threading;

namespace VinterITS32019Eksamen
{
    partial class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<VO2DataContainer> _vo2DataCollection = new BlockingCollection<VO2DataContainer>();
            ISensor randomSensor = new RandomSensor();
            IFitnessRatingCalculatorStrategy fitnessRatingCalculatorStrategy = new MaxFitnessRatingStrategy();

            //Read configuration from file
            //var systemConfiguration = ConfigurationSerialization.Load(@"..\..\fitnessratingconfig.xml");

            //Initialize system
            //Producer
            VO2SensorProducer vO2SensorProducer = new VO2SensorProducer(_vo2DataCollection,randomSensor);

            //Consumer
            FitnessRatingControlConsumer fitnessRatingControlConsumer = new FitnessRatingControlConsumer(_vo2DataCollection, fitnessRatingCalculatorStrategy);

            var rapport =
                new RapportConcreteObserver(new MaxFitnessRatingStrategy(), fitnessRatingControlConsumer);


            //Run System
            Thread vO2SensorProducerThread = new Thread(vO2SensorProducer.Run);
            Thread fitnessRatingControlConsumerThread = new Thread(fitnessRatingControlConsumer.Run);

            //Start threads
            vO2SensorProducerThread.Start();
            fitnessRatingControlConsumerThread.Start();


            //fitnessRatingControlConsumer.Detach(rapport);

            var cont = true;

            Console.WriteLine("Control Menu:");
            Console.WriteLine("-------------------");
            Console.WriteLine("[S]    Start");
            Console.WriteLine("[E]    Stop");
            Console.WriteLine("[A]    AverageFitnessRating");
            Console.WriteLine("[M]    MaxFitnessRating");


            while (cont)
            {
                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 's':
                    case 'S':
                        fitnessRatingControlConsumer.Start();
                        break;
                    case 'e':
                    case 'E':
                        fitnessRatingControlConsumer.Stop();
                        break;
                    case 'a':
                    case 'A':
                        fitnessRatingControlConsumer._fitnessRatingCalculatorStrategy = new AverageFitnessRatingStrategy();
                        break;
                    case 'm':
                    case 'M':
                        fitnessRatingControlConsumer._fitnessRatingCalculatorStrategy = new MaxFitnessRatingStrategy();
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
