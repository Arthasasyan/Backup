using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace Backup
{

    /// <summary>
    /// Class for settings
    /// </summary>
    [DataContract]
    public class Settings
    {
        [DataMember]
        public string[] DirsToBackup { get; set; }
        [DataMember]
        public string BackupDir { get; set; }
        [DataMember]
        public string LoggerPath { get; set; }

        /// <summary>
        /// Deserializing settings file
        /// </summary>
        /// <param name="path">Path to settings file</param>
        /// <returns>Settings object</returns>
        public static Settings Parse(string path)
        {
            if (!File.Exists(path))
            {
                throw  new FileNotFoundException("Settings file not found");
            }
            Settings settings = null;
            DataContractJsonSerializer jsonDerializer = new DataContractJsonSerializer(typeof(Settings));
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                settings = jsonDerializer.ReadObject(fileStream) as Settings;
                return settings;
            }

        }

    }
}