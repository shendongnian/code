            static void Main(string[] args)
            {
                Cars one = new Cars { Name = "Ford" };
                Cars two = new Cars { Name = "Audi" };
                Cars three = new Cars { Name = "Lamborghini" };
                Cars four = new Cars { Name = "Ferrari" };
    
                List<Cars> _lstCars = new List<Cars>();
                _lstCars.Add(one);
                _lstCars.Add(two);
                _lstCars.Add(three);
                _lstCars.Add(four);
                SortByName sortbyname = new SortByName();
                _lstCars.Sort(sortbyname);
                Console.WriteLine("Result After sorting by name");
                foreach (var item in _lstCars)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine();
                }
                Console.Read();
            }
