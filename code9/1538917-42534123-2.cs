        static void Main(string[] args)
        {
            IList<Item> myList = new List<Item>() { new Item { Id = "123" }, new Item { Id = "abc" }, new Item { Id = "XYZ" } };
            var newItem = new Item { Id = "abc" };
            var oldItem = myList.Single(x => x.Id == newItem.Id);
            myList = Replace(myList, oldItem, newItem);
        }
