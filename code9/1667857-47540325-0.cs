    public class ItemCollectionSpecimenCommand : ISpecimenCommand
    {
        public void Execute(object specimen, ISpecimenContext context)
        {
            var @is = specimen as IEnumerable<Item>;
            if (@is == null)
                return;
            var items = @is.ToList();
            if (items.Count < 3)
                return;
            var week1 = context.Create<Week>();
            var week2 = context.Create<Week>();
            items[0].Week = week1;
            items[1].Week = week1;
            items[2].Week = week2;
            items.GroupBy(t => t.Week).ToList().ForEach(ConfigureNames);
        }
        private static void ConfigureNames(IEnumerable<Item> items)
        {
            string name = null;
            foreach (var item in items)
            {
                if (name == null)
                    name = item.Name;
                else
                    item.Name = name;
            }
        }
    }
