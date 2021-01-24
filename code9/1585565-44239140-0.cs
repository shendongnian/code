    public class MyController : Controller
    {
        private readonly MyDbContext _context;
        public MyController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult AddFirst()
        {
            var user = new User
            {
                Name = "Alice"
            };
            _context.Users.Add(user);
            var team = new Team
            {
                Id = "uniqueteamid",
                Name = "A Team"
            };
            _context.Teams.Add(team);
            var teamuser1 = new TeamUser()
            {
                User = user,
                Team = team
            };
            _context.TeamUsers.Add(teamuser1);
            _context.SaveChanges();
            return View();
        }
        public IActionResult AddSecond()
        {
            var teamuser2 = new TeamUser()
            {
                UserName = "Alice",
                TeamId = "uniqueteamid"
            };
            _context.TeamUsers.Add(teamuser2);
            _context.SaveChanges();
            return View();
        }
        public IActionResult AddFirstAndSecond()
        {
            var user = new User
            {
                Name = "Bob"
            };
            _context.Users.Add(user);
            var team = new Team
            {
                Id = "anotherteamid",
                Name = "B Team"
            };
            _context.Teams.Add(team);
            var teamuser1 = new TeamUser()
            {
                User = user,
                Team = team
            };
            _context.TeamUsers.Add(teamuser1);
            var teamuser2 = new TeamUser()
            {
                User = user,
                Team = team
            };
            _context.TeamUsers.Add(teamuser2);
            _context.SaveChanges();
            return View();
        }
        public IActionResult AddFirstAndSecondAgain()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-WebApplication1;Trusted_Connection=True;MultipleActiveResultSets=true");
            using (var context = new MyDbContext(optionsBuilder.Options))
            {
                var user = new User
                {
                    Name = "Cat"
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
            using (var context = new MyDbContext(optionsBuilder.Options))
            {
                var team = new Team
                {
                    Id = "andanotherteamid",
                    Name = "C Team"
                };
                context.Teams.Add(team);
                context.SaveChanges();
            }
            using (var context = new MyDbContext(optionsBuilder.Options))
            {
                var teamuser1 = new TeamUser()
                {
                    UserName = "Cat",
                    TeamId = "andanotherteamid"
                };
                context.TeamUsers.Add(teamuser1);
                context.SaveChanges();
            }
            using (var context = new MyDbContext(optionsBuilder.Options))
            {
                var teamuser2 = new TeamUser()
                {
                    UserName = "Cat",
                    TeamId = "andanotherteamid"
                };
                context.TeamUsers.Add(teamuser2);
                context.SaveChanges();
            }
            return View();
        }
    }
