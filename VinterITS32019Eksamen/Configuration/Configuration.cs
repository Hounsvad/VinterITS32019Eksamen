namespace VinterITS32019Eksamen
{
    public class Configuration
    {
        public string Gender{ get; set; }
        public string Name{ get; set; }
        public double Weight{ get; set; }
        public string VO2SensorType{ get; set; }

        public Configuration()
        {
            Gender = "Female";
            Name = "Jane";
            Weight = 70;
            VO2SensorType = "random";
        }
    }
}