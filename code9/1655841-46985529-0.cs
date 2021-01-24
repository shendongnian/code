    public interface ISystemEnvironment {
        string GetEnvironmentVariable(string variable);
    }
    public class SystemEnvironmentService : ISystemEnvironment {
        public string GetEnvironmentVariable(string variable) {
            return System.Environment.GetEnvironmentVariable(variable);
        }
    }
