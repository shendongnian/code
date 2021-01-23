    public class ContactManager
    {
        public static ObservableCollection<Contact> GetContacts()
        {
            var contact1 = new ObservableCollection<Contact>();
            contact1.Add(new Contact { Name = "Nguyen Van A", Phone = "0168111222", Photo = "Assets/1.jpg" });
            contact1.Add(new Contact { Name = "Tran Van B", Phone = " 0168333444", Photo = "Assets/2.jpg" });
            contact1.Add(new Contact { Name = "Le Van C", Phone = "0166555666", Photo = "Assets/3.jpg" });
            return contact1;
        }
    }
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Contact> MyContactList;
        private string path;
        private SQLite.Net.SQLiteConnection connection;
        public MainPage()
        {
            this.InitializeComponent();
            MyContactList = ContactManager.GetContacts();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            connection = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            var f = connection.CreateTable<Contact>();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var s = connection.Insert(new HNT_listView2.Models.Contact
            {
                Name = name_textBox.Text,
                Phone = phone_textBox.Text,
                Photo = photo_textBox.Text
            });
            Debug.WriteLine("Added");
        }
        public void Refresh_Click(Object sender, RoutedEventArgs e)
        {
            var query = connection.Table<Contact>();
            string name = "";
            string phone = "";
            string photo = "";
            foreach (var x in query)
            {
                name = name + "" + x.Name;
                phone = phone + "" + x.Phone;
                photo = photo + "" + x.Photo;
            }
            MyContactList.Add(new Contact { Name = "" + name, Phone = "" + phone, Photo = "" + photo });
        }
    }
