    public interface ISettings
    {
       void setSettings();
    } 
        public class realSettings : ISettings
        {  
           public string settings;
           public void setSettings(){}
        }
    ISetting set=new realSettings();
