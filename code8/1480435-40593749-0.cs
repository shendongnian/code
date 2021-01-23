    class Program
        {
            static void Main(string[] args)
            {
                FoodItem firstfood = new FoodItem("Spagetti", 3);
                Console.WriteLine("The First Food is '{0}' And it serves {1}",   firstfood.Name, firstfood.NumberServed);
            }
        }
    class FoodItem
        {
            string _name;       
            int _numberserved;
    
            public void food(string name)  
            public FoodItem()
            {
                _name = name;
                _numberserved = 0;
            }
            public void food(string name, int numberserved)
            public FoodItem(string name, int numberserved)
    
            {
                _name = name;
                NumberServed = numberserved;
            }
    
            public string Name
            {
                get
                {
                    return _name;
                }
            }
    
            public int NumberServed
            {
                get
                {
                    return _numberserved;
                }
                set
                {
                    if (value > 4)
                    {
                        _numberserved = 4;
                    }
                    else
                    {
                        _numberserved = value;
                    }
                }
            }
        }    
