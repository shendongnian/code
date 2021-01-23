    public static class Machine 
    {
        public static string User(){
            return Environment.GetEnvironmentVariable("USERNAME") ?? Environment.GetEnvironmentVariable("USER");
        }
    
        public static string Domain(){
            return Environment.GetEnvironmentVariable("USERDOMAIN") ?? Environment.GetEnvironmentVariable("HOSTNAME");
        }
    }
