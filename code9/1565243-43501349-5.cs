        static void Main(string[] args)
        {
            AlwaysCreateNewDatabase();
            CarBrand hondaDb = null;
            using (var context = new MyContext())
            {
                hondaDb = context.CarBrands.Add(new CarBrand {Name = "Honda"}).Entity;
                context.SaveChanges();
            }
            using (var context = new MyContext())
            {
                var car2 = new Car() { CarBrandId = hondaDb.CarBrandId };
                context.Cars.Add(car2);
                context.SaveChanges();
            }
        }
