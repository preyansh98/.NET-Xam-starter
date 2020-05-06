using System; 
using System.IO;

namespace ProfileAPI.Domain
{
    public class ProfileDatabaseSettings : IProfileDatabaseSettings
    {

        public ProfileDatabaseSettings() {
            DbConnectionString = readDbStringFromFile(); 
        }

        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string DbConnectionString {get; set; }
 
 
        //hotfix way to get env
        private static string readDbStringFromFile(){            
            using (StreamReader sr = new StreamReader("sysvars.env"))
                {
                    String line = sr.ReadToEnd();
                    return line; 
                }
        }
    }

    public interface IProfileDatabaseSettings
    {
        string CollectionName { get; set; }
        string DatabaseName { get; set; }
        string DbConnectionString { get; set; }
    }
}