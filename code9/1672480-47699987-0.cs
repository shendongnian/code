        static void Main()
        {
            var items = new List<Item>();
            items.Add(new Item { Value = 26 });
            items.Add(new Item { Value = 31 });
            items.Add(new Item { Value = 47 });
            items.Add(new Item { Value = 175 });
            items.Add(new Item { Value = 50 });
            items.Add(new Item { Value = 1 });
            items.Add(new Item { Value = 74 });
            items.Add(new Item { Value = 8 });
            items.Add(new Item { Value = 219 });
            items.Add(new Item { Value = 169 });
            int sum = items.Sum(x => x.Value);
            double minPercentage = 0.01;
            System.Console.WriteLine("Value - Percent");
            foreach (var item in items)
            {
                item.Percent = item.Value / (double)sum;
                System.Console.WriteLine(item.Value + " - " + item.Percent);
            }
            System.Console.WriteLine("---------");
            System.Console.WriteLine(items.Sum(x => x.Value) + " - " + items.Sum(x => x.Percent));
            System.Console.WriteLine("\n");
            CalculatePercents(items,minPercentage);
            System.Console.WriteLine("Value - Percent");
            foreach (var item in items)
            {
                System.Console.WriteLine(item.Value + " - " + item.Percent);
            }
            System.Console.WriteLine("---------");
            System.Console.WriteLine(items.Sum(x => x.Value) + " - " + items.Sum(x => x.Percent));
            System.Console.ReadLine();
            Console.ReadLine();
        }
        private static void CalculatePercents(List<Item> items,double minPercentage)
        {
            var itemsLessThanOnePercent = items.Where(x => x.Percent < minPercentage).ToList();
            var itemsGreaterThanOrEqualToOnePercent = items.Where(x => x.Percent >= minPercentage).ToList();
            double totalPercentageLessThanOne = itemsLessThanOnePercent.Sum(x => x.Percent);
            double reduceEachGreaterThanOneBy = ((itemsLessThanOnePercent.Count() * minPercentage) - totalPercentageLessThanOne) / itemsGreaterThanOrEqualToOnePercent.Count();
            foreach (var item in itemsGreaterThanOrEqualToOnePercent)
            {
                item.Percent = item.Percent - reduceEachGreaterThanOneBy;
            }
            foreach (var item in itemsLessThanOnePercent)
            {
                item.Percent = minPercentage;
            }
            var minPercentagesItems = items.Where(x => x.Percent < minPercentage).ToList();
            if (minPercentagesItems.Count == 0)
            {
                return;
            }
            CalculatePercents(minPercentagesItems,minPercentage);
        }
