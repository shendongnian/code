    public struct ListboxData
    {        
        public ListboxData(
            int id,
            string category,
            string name,
            params string[] tags) : this()
        {
            this.ID = id;
            this.Category = category;
            this.Name = name;
            this.Tags = new List<string>();
            this.Tags.AddRange(tags);
        }      
        public int ID { get; private set; }
        public string Category { get;  private set;}
        public string Name { get;  private set;}
        public List<string> Tags { get;  private set;}
        
        public string[] ToStringArray() 
        {
            return new[] {
                ID.ToString(),
                Category,
                Name,
                string.Join(";", Tags)
            };
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            Console.WriteLine("Hello, world!");
            
            var list = new List<ListboxData>();
            list.Add(new ListboxData(1001, "COOLING", "Cooling Intro"));
            list.Add(new ListboxData(1002, "COOLING", "Cooling Adanced"));
            list.Add(new ListboxData(1003, "COOLING", "Cooling Tests"));
            list.Add(new ListboxData(1004, "HEATING", "Heating Intro", "tag1", "tag2"));
            
            // Get all cooling ID's
            int[] ids = list.Where((item)=> item.Category=="COOLING").Select( (item)=> item.ID).ToArray();
            // { 1001, 1002, 1003 }
            
            foreach(var item in ids)
            {
                Console.WriteLine(item);
            }
            
            // Get all items that contain "Intro" in the name
            ListboxData[] intro = list.Where((item)=>item.Name.Contains("Intro")).ToArray();
            // { list[0], list[3] }
            foreach(var item in intro)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
