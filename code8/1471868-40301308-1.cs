    public interface ISettings
    {
       void setSettings();
    } 
        public class realSettings : ISettings
        {  
           public string settings;
           public string ConnectionString;
           public void setSettings(){
           // set the connectionString here the way you want.
           }
        }
    ISetting set=new realSettings();
