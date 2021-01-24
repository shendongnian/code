    public class Settings : ISettings {
        public string ConnectionString {
            get {
                try {
                    var value = ConfigurationManager.ConnectionStrings["SqlCon"].ToString();
                    return value;
                } catch(Exception ex) {
                    throw;
                }
            }
        }
    }
