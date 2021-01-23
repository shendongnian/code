    using Microsoft.AspNetCore.Hosting;
    using System;
    public class Program {
        private static string HostingEnvironment => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        private static bool IsEnvironment(string environmentName) => HostingEnvironment?.ToLower() == environmentName?.ToLower() && null != environmentName;
        private static bool Development => IsEnvironment(EnvironmentName.Development);
        private static bool Production => IsEnvironment(EnvironmentName.Production);
        private static bool Staging => IsEnvironment(EnvironmentName.Staging);
        public static void Main(string[] args) { // Your code here }
    }
