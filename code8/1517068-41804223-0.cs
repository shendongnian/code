    public class Program
    {
        static void Main()
        {
            MyMenu = new Menu();
            Articles = myMenu.Add("Articles");
            MyMenu.Add("Customers");
        }
 
        public static Menu MyMenu {get; private set;}
        public static MenuItem Articles { get; private set;}
    }
