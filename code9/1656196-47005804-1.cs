    List<Beverage> drinks = new List<Beverage>()
    {
        new Beverage {Description = "", Price = 0m},
        new Beverage {Description = "Soda", Price = 1.95m},
        new Beverage {Description = "Tea", Price = 1.50m},
        new Beverage {Description = "Coffee", Price = 1.25m},
        new Beverage {Description = "Mineral Water", Price = 2.95m}
    };
    comboBoxBeverage.DropDownStyle = ComboBoxStyle.DropDownList;
    comboBoxBeverage.DataSource = drinks;
