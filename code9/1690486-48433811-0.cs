    static IEnumerable<MenuItem> RootMenu;
    static void Main(string[] args)
    {
      RootMenu = BuildRootMenu();
      MenuItem.DisplayMenu(RootMenu, new Atm());
    }
    /// <summary>
    /// Creates the entire menu
    /// </summary>
    static IEnumerable<MenuItem> BuildRootMenu()
    {
      MenuItem item1 = new MenuItem() { DisplayText = "Create Account", AtmAction = (a) => a.CreateAccount() };
      MenuItem item2_1 = new MenuItem() { DisplayText = "Deposit", AtmAction = (a) => a.Deposit() };
      MenuItem item2_2 = new MenuItem() { DisplayText = "Withdraw", AtmAction = (a) => a.Withdraw() };
      MenuItem item2 = new MenuItem() { DisplayText = "ATM", AtmAction = (a) => MenuItem.DisplayMenu(new List<MenuItem> { item2_1, item2_2 }, a) };
      MenuItem item3 = new MenuItem() { DisplayText = "Account Info", AtmAction = (a) => a.CreateAccount() };
      return new List<MenuItem> { item1, item2, item3 };
    }
    class MenuItem
    {
      public String DisplayText;
      public Action<Atm> AtmAction = null;
      public void Execute(Atm atm)
      {
        AtmAction(atm);
        DisplayMenu(RootMenu, atm);
      }
      public static void DisplayMenu(IEnumerable<MenuItem> menuItems, Atm atm)
      {
        int i = 1;
        foreach (var mi in menuItems)
        {
          Console.WriteLine(i + ": " + mi.DisplayText);
          i++;
        }
        var rk = Console.ReadKey();
        menuItems.ToArray()[int.Parse(rk.KeyChar.ToString()) - 1].Execute(atm);
      }
    }
    class Atm
    {
      public void Deposit()
      {
        Console.WriteLine("Ran Deposit");
      }
      public void Withdraw()
      {
        Console.WriteLine("Ran Withdraw");
      }
      public void CreateAccount()
      {
        Console.WriteLine("Ran CreateAccount");
      }
      public void AccountInfo()
      {
        Console.WriteLine("Ran AccountInfo");
      }
