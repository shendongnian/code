    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Forest, ForestEF>().PreserveReferences();
                    cfg.CreateMap<Section, SectionEF>().PreserveReferences();
                    cfg.CreateMap<Tree, TreeEF>().PreserveReferences();
                });
            var mapper = config.CreateMapper();
            var forest = new Forest();
            var section = new Section();
            var tree = new Tree();
            forest.Trees.Add(tree);
            forest.Sections.Add(section);
            section.Trees.Add(tree);
            var result = mapper.Map<Forest, ForestEF>(forest);
            Console.WriteLine(object.ReferenceEquals(result.Trees[0], result.Sections[0].Trees[0]));
            Console.ReadLine();
        }
    }
    public class Forest
    {
        public IList<Tree> Trees { get; set; } = new List<Tree>();
        public IList<Section> Sections { get; set; } = new List<Section>();
    }
    public class Section
    {
        public IList<Tree> Trees { get; set; } = new List<Tree>();
    }
    public class Tree
    {
    }
    public class ForestEF
    {
        public IList<TreeEF> Trees { get; set; } = new List<TreeEF>();
        public IList<SectionEF> Sections { get; set; } = new List<SectionEF>();
    }
    public class SectionEF
    {
        public IList<TreeEF> Trees { get; set; } = new List<TreeEF>();
    }
    public class TreeEF
    {
    }
