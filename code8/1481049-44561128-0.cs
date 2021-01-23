    public static class EnumExtentions
    {
        static public IStringLocalizerFactory StringLocalizerFactory { set; get; }
        public static string GetDisplayName(this Enum e)
        {
            var resourceManager = StringLocalizerFactory.Create(e.GetType());
            var key = e.ToString();
            var resourceDisplayName = resourceManager.GetString(key);
            return resourceDisplayName;
        }
    }
