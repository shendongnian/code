            public Weapon swords(int weaponNumber)
            {
               switch (weaponNumber)
               {
                    case (1);
                         return new Weapon() {
                            name = "Wooden Sword",
                            damage = 2,
                            magic = 1,
                            durability = 20,
                            price = 10
                          };
                    case (2):
                       return new Weapon() {
                           name = "Iron Sword",
                           damage = 3,
                           magic = 2,
                           durability = 50,
                           price = 20
                         };
                    default:
                         return null; //Or some other default for when it doesn't exist
                }
           }
