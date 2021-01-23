    using System.Windows.Forms;
    using System.Reflection;
    
    namespace First
    {
        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserID { get; set; }
    
            public User()
            {
    
            }
        }
    }
    
    namespace Second
    {
        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserID { get; set; }
    
            public User()
            {
    
            }
        }
    }
    
    namespace YetAnotherNamespace
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                First.User user = new First.User()
                {
                    FirstName = "John",
                    LastName = "Public",
                    UserID = "jpublic@mydomain.com"
                };
    
                Second.User newUser = ConvertUser(user);
    
            }
    
            public Second.User ConvertUser(First.User input)
            {
                Second.User newUser = new Second.User();
    
                foreach (PropertyInfo prop in input.GetType().GetProperties())
                {
                    string propertyName = prop.Name;
                    object propertyValue = prop.GetValue(input);
                    newUser.GetType().GetProperty(propertyName).SetValue(newUser, propertyValue);
                }
    
                return newUser;
            }
        }
    }
