    public class YourObject_ByName : AbstractIndexCreationTask<YourObject>
    {
        public YourObject_ByName()
        {
            Map = objs => objs .Select(x => new { x.Name });
            Indexes.Add(x => x.Name, FieldIndexing.Analyzed);
        }
    }
