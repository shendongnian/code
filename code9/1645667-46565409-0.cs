    class Program
    {
        static void Main(string[] args)
        {
            //Required list
            List<Order> currentItemsInColl = new List<Order>();
            currentItemsInColl.Add(new Order() { Name = "bike1", Id = "01" });
            currentItemsInColl.Add(new Order() { Name = "bike4", Id = "04" });
            //List of all items
            List<BPP> bPList = new List<BPP>();
            bPList.Add(new BPP() { BikeName = "bike1", Idzzz = "01" });
            bPList.Add(new BPP() { BikeName = "bike2", Idzzz = "02" });
            bPList.Add(new BPP() { BikeName = "bike3", Idzzz = "03" });
            bPList.Add(new BPP() { BikeName = "bike4", Idzzz = "04" });
            bPList.Add(new BPP() { BikeName = "bike5", Idzzz = "05" });
            //Blueprint List
            List<BPP> Blueprint = new List<BPP>();
            //get all items into the Blueprint list
            foreach (Order i in currentItemsInColl)
            {
                List<BPP> tmp = bPList.FindAll(x => x.Idzzz.Contains(i.Id));
                //here you add them all to a list
                foreach (BPP item in tmp)
                {
                    Blueprint.Add(item);
                }
            }
            
            Console.ReadLine();
        }
    }
    public class Order
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class BPP
    {
        public string Idzzz { get; set; }
        public string BikeName { get; set; }
    }
