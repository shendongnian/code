    namespace WpfDataGridSample {
     public partial class MainWindow : Window {
        public List<User> User { get; set; }
        public MainWindow() {
            InitializeComponent();
            User = new List<User>();
            var user1 = new User() {
                Id = 1,
                Name = "John Doe",
                Birthday = new DateTime(1971, 7, 23)
            };
            user1.Address.Add(new Address() {
                Street = "Teststreet1",
                Number = 1
            });
            user1.Address.Add(new Address() {
                Street = "Teststreet1",
                Number = 11
            });
            User.Add(user1);
            var user2 = new User() {
                Id = 2,
                Name = "Jane Doe",
                Birthday = new DateTime(1974, 1, 17)
            };
            user2.Address.Add(new Address() {
                Street = "Teststreet2",
                Number = 2
            });
            user2.Address.Add(new Address() {
                Street = "Teststreet2",
                Number = 22
            });
            User.Add(user2);
            var user3 = new User() {
                Id = 3,
                Name = "Sammy Doe",
                Birthday = new DateTime(1991, 9, 2)
            };
            user3.Address.Add(new Address() {
                Street = "Teststreet3",
                Number = 3
            });
            user3.Address.Add(new Address() {
                Street = "Teststreet3",
                Number = 33
            });
            User.Add(user3);
            this.DataContext = this;
        }      
    }
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public List<Address> Address { get; set; }
        public User() {
            Address = new List<Address>();
        }
    }
    public class Address {
        public string Street { get; set; }
        public int Number { get; set; }
    }
    }
