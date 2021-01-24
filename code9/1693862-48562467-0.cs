    public class PicturePage<T> where T : LocalDataFolder
    {
        public List<T> folders = new List<T>() { };
        public void Put()
        {
            foreach (T item in folders)
                Console.WriteLine(item.type); 
        }
    }
