     Rootobject root = new Rootobject
        {
            Place = new Place
            {
                stores = new List<Store>
                {
                    new Store{
                       Grocery = new Grocery
                      {
                        stock ="fruit",
                        distance = 19,
                        size = 12
                      },
                     Department = new Department
                    {
                        stock ="clothing",
                        distance = 21,
                        size = 7
                    }
                   }
                }
            }
        };
I wrote it from my head, so I hope syntax is good. But main idea is that you were creating list of stores and not any store inside that list. You should create some Store using new Store
