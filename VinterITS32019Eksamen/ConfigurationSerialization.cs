using System.IO;
using System.Xml.Serialization;

namespace VinterITS32019Eksamen
{
    public class ConfigurationSerialization
    {
        //Save
        public static void Save(Configuration configuration, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));

                serializer.Serialize(fs, configuration);
                fs.Close();
            }
        }
        //Load
        public static Configuration Load(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));

                Configuration configuration = (Configuration) serializer.Deserialize(fs);

                return configuration;
            }
        }
    }
}