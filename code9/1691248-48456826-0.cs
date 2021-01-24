    public interface IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public bool IsActive { get; set; }
    }
    public class Species :IData {}
    public class Chemical :IData {}
