    public static class MyEnumExtensions
    {
        public static int Val(this PublicData en)
        {
            return (int)Enum.Parse(typeof(PublicData), en.ToString());            
        }
    }
