    public class MyFileInfo
    {
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            if (obj?.GetType() == typeof(MyFileInfo))
            {
                return ((MyFileInfo)obj).Name == Name;
            }
            return false;
        }
    }
