    using System;
    using System.Collections.Generic;
    
    public class Item
    {
        public static List<Item> Database;
    
        static Item()
        {
            Database = new List<Item>();
        }
    
        public Item(string name, int start, int end, params string[] orders)
        {
            Name = name;
            Start = start;
            End = end;
            Orders = new List<string>();
            foreach (string s in orders)
                Orders.Add(s);
            //putting newly created Item to database
            Database.Add(this);
        }
    
        //overload for creating tmp Items in GroupThem(), could be done using optinional parameter
        public Item(bool AddToDatabase, string name, int start, int end, params string[] orders)
        {
            Name = name;
            Start = start;
            End = end;
            Orders = new List<string>();
            foreach (string s in orders)
                Orders.Add(s);
            if (AddToDatabase) Database.Add(this);
        }
    
        public string Name { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public List<string> Orders { get; set; }
    
        public List<Item> GroupedItems()
        {
            List<Item> groupedItems = new List<Item>();
            Item previous = Database[0];
            Stack<Item> sameItems = new Stack<Item>();
    
            foreach (Item item in Database)
            {
                if (previous.Name == item.Name)
                {
                    sameItems.Push(item);
                }
                else
                {
                    groupedItems.Add(GroupThem(sameItems));
                    previous = item;
                    sameItems.Push(item);
                }
            }
            groupedItems.Add(GroupThem(sameItems));
            return groupedItems;
        }
    
        private Item GroupThem(Stack<Item> sameItems)
        {
            string newName = "";
            int newEnd = 0;
            int newStart = int.MaxValue;
            List<string> newOrders = new List<string>();
            Item tmp = null;
            while (sameItems.Count > 0)
            {
                tmp = sameItems.Pop();
                if (tmp.Start < newStart)
                    newStart = tmp.Start;
                if (tmp.End > newEnd)
                    newEnd = tmp.End;
                foreach (string s in tmp.Orders)
                    if (!newOrders.Contains(s))
                        newOrders.Add(s);
                newName = tmp.Name;
            }
            return new Item(false, newName, newStart, newEnd, newOrders.ToArray());
        }
    
        public override string ToString()
        {
            string tmp = "";
            foreach (string s in Orders)
                tmp += " " + s;
            return "Name = " + Name + ", Start = " + Start + ", End = " + End +", Orders  = "+ tmp;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
    
            Item item1 = new Item("A", 1, 2, "C", "D");
            Item item2 = new Item("A", 2, 3, "C", "E");
            Item item3 = new Item("B", 4, 5, "F");
            Item item4 = new Item("A", 6, 7);
            Item item5 = new Item("A", 7, 8, "D");
            Item item6 = new Item("A", 9, 10, "E");
    
            foreach (Item item in item1.GroupedItems())
            {
                Console.WriteLine(item);
            }
        }
    }
