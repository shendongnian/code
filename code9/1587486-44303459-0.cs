        public interface IConfigFiles
        {
            List<string> Files { get; set; }
        }
        public DemoCls(IConfigFiles files)
        {
        }
