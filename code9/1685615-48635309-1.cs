    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
    
            var users = new List<UserListingVM>
                {
                    new UserListingVM
                    {
                        Id = 1,
                        Email = "test@gmail.com"
                    },
                    new UserListingVM
                    {
                        Id = 2,
                        Email = "johndoe@gmail.com"
                    },
                    new UserListingVM
                    {
                        Id = 3,
                        Email = "larryjoe@gmail.com"
                    },
                };
    
            var userEmails = users.Select(u => u.Email).ToList();
            Log.Debug("Displaying Users {@Users}", userEmails);
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
    
    class UserListingVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
