using VinterITS32019Eksamen;

namespace VinterITS32019Eksamen
{
    public class RapportConcreteObserver:IObserver
    {
        private readonly FitnessRatingControlConsumer _fitnessRatingControlConsumer;
        public IFitnessRatingCalculatorStrategy fitnessRatingCalculatorStrategy{ private get; set; }

        public RapportConcreteObserver(IFitnessRatingCalculatorStrategy calculatorStrategy,
            FitnessRatingControlConsumer fitnessRatingControlConsumer)
        {
            fitnessRatingCalculatorStrategy = calculatorStrategy;
            fitnessRatingControlConsumer.Attach(this);
            _fitnessRatingControlConsumer = fitnessRatingControlConsumer;
        }

        public void Update()
        {
            if (_fitnessRatingControlConsumer.isActive == false)
            {
                _fitnessRatingControlConsumer.Start();
            }
            else
            {
                _fitnessRatingControlConsumer.Stop();
            }
        }

        
    }
}