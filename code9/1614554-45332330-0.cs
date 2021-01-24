    namespace ConsoleApplication5
    {
        public abstract class BaseUser
        {
            public string Email { get; set; }
            public string OtherLocation { get; set;}
        }
    
        public class UserA : BaseUser
        {
            public string Location { get; set; }
            public string OtherLocation {
              get
              {
                return this.Location;
              }
              set
              {
                this.Location = value;
              }
            }
        }
        public class UserB : BaseUser
        {
            public string State { get; set; }
            public string OtherLocation {
              get
              {
                return this.State;
              }
              set
              {
                this.State = value;
              }
            }
        }
    
        public class UserARepo
        {
            void Print(BaseUser user)
            {
                Console.Write($"User A Saved {user.Email}, {user.OtherLocation}");
            }
        }
        public class UserBRepo
        {
            void Print(BaseUser user)
            {
                Console.Write($"User B Saved {user.Email}, {user.OtherLocation}");
            }
        }
    }
