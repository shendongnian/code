    public class Configuration {
    }
    public interface IConfigurationReader {
        IEnumerable<Configuration> GetEnabledConfigurations();
    }
    public class MyController {
        private IConfigurationReader configReader;
        public MyController(IConfigurationReader configReader) {
            this.configReader = configReader;
        }
        public virtual bool EntranceMethod() {
            // read configuration to determine which methods to call
            var config = configReader.GetEnabledConfigurations();
            //...code for example purposes only
            if (config != null) {
                WorkerMethod1();
                WorkerMethod2();
                WorkerMethod3();
                return true;
            }
            return false;
        }
        public virtual void WorkerMethod1() {
            //... 
        }
        public virtual void WorkerMethod2() {
            //... 
        }
        public virtual void WorkerMethod3() {
            //... 
        }
    }
