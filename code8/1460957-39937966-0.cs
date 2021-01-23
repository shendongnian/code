        static void Main(string[] args)
        {
            Brand brand = new Brand();
           string brandName  = brand.getBrandName();
           Console.WriteLine("You enter correct brand name !!!");
           Console.WriteLine(brandName);
           Console.ReadLine();
        }
        public class Brand
        {
            private string brandName;
            public string BrandName
            {
                get { return brandName; }
                set { brandName = value; }
            }
            public string getBrandName()
            {
                bool isValid = false;
                string temp = "";
                string[] brands = new string[5];
                brands[0] = "Honda";
                brands[1] = "Suzuki";
                brands[2] = "Ferrari";
                brands[3] = "BMW";
                brands[4] = "Toyota";
                Console.WriteLine("Please enter the brand name from the above given   brands..");
               
                while (!isValid)
                {
                    for (int i = 0; i < brands.Length; i++)
                    {
                        Console.WriteLine(brands[i]);
                    }
                    temp = Console.ReadLine();
                    for (int i = 0; i < brands.Length; i++)
                    {
                        if (brands[i] == temp)
                        {
                            this.BrandName = temp;
                            isValid = true;
                            break;
                        }
                        else
                        {
                            isValid = false;
                        }
                        if (i == brands.Length - 1)
                        {
                            Console.WriteLine("Your provide brand does not match with the database in our system. Please try another one.");
                        }
                    }
                }
                return temp;
            }
        }
    }
