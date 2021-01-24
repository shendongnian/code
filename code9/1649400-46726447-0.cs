    public IDictionary<int, Weapon> swords()
        {
           var dict = new Dictionary<int, Weapon> swords() {
           1, new Weapon {
               name = "Wooden Sword",
               damage = 2,
               magic = 1,
               durability = 20,
               price = 10
           },
           2, new Weapon {
               name = "Iron Sword",
               damage = 3,
               magic = 2,
               durability = 50,
               price = 20
           }
        };
        return dict;
    }
