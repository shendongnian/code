    public class SoftwareProductRepository
    {
        BitDatabaseEntities bitDB = new BitDatabaseEntities();
        public IEnumerable<BuildMetrics> GetBuildMetrics()
        {
            return (from r in bitDB.bit_sanity_results select r).ToList();
        }
    }
