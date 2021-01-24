    class Program
    {
        public static List<ToolType> ToolTypes { get; set; }
        static void Main(string[] args)
        {
            var mefContainer = new MefContainer();
            ToolTypes = mefContainer.Container.GetExportedValues<ToolType>().ToList();
            ToolTypes.First(x => x.GetType() == typeof(Brush))?.Test();
            ToolTypes.First(x => x.GetType() == typeof(Eraser))?.Test();
            ToolTypes.First(x => x.GetType() == typeof(Drag))?.Test();
        }
    }
