using System;
using System.Collections.Concurrent;
using System.Threading;

namespace VinterITS32019Eksamen
{
    public class FitnessRatingControlConsumer:Subject
    {

        private readonly BlockingCollection<VO2DataContainer> _vo2DataCollection;

        public IFitnessRatingCalculatorStrategy _fitnessRatingCalculatorStrategy { get; set; } //Property så vi kan ændre det

        public bool CurrentPresenceState = false;

        public bool isActive{ get; set; }

        public FitnessRatingControlConsumer(BlockingCollection<VO2DataContainer> vo2DataCollection, IFitnessRatingCalculatorStrategy fitnessRatingCalculatorStrategy)
        {
            _vo2DataCollection = vo2DataCollection;
            _fitnessRatingCalculatorStrategy = fitnessRatingCalculatorStrategy;
            isActive = false;
        }

        public void Run()
        {
            while (true)
            {
                HandleOneVO2Samples();
            }
        }

        //public void HandleOneVO2Samples()
        //{
        //    //try
        //    //{
        //        //var newPresenceState = isActive;
        //        //if (newPresenceState != CurrentPresenceState)
        //        //{
        //        //    CurrentPresenceState = newPresenceState;
        //        //    Notify();
        //        //}
        //        while (true)
        //        {
        //            if (isActive != CurrentPresenceState)
        //            {
        //                CurrentPresenceState = isActive;
        //                Notify();
        //            }
        //        }

        //        //}
        //    //catch(InvalidOperationException){}
        //}

        public void HandleOneVO2Samples()
        {
            try
            {
                Notify();
                //if (isActive)
                //{
                //    Start();
                //}
                //else if (!isActive)
                //{
                //    Stop();
                //}
            }
            catch (InvalidOperationException)
            {

            }
        }


        public void Start()
        {
            isActive = true;
            VO2DataContainer container = _vo2DataCollection.Take();
            var value = container.VO2Sample;
            Console.WriteLine(value);

            //Strategy
            //_fitnessRatingCalculatorStrategy.AddToList(value);
            _fitnessRatingCalculatorStrategy.AddToList(value);
        }

        public void Stop()
        {
            isActive = false;
            _vo2DataCollection.Take();
            
            try
            {
                //var rating = _fitnessRatingCalculatorStrategy1.GetFitnessRating();
                //_fitnessRatingCalculatorStrategy.Print(rating);
                //_fitnessRatingCalculatorStrategy1.ClearList();

                //Notify();
                var rating = _fitnessRatingCalculatorStrategy.CalculateFitnessRating();
                _fitnessRatingCalculatorStrategy.Print(rating);
                _fitnessRatingCalculatorStrategy.ClearList();
            }
            catch (DivideByZeroException)
            {

            }
        }
    }
}