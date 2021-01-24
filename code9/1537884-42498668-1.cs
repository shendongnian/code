    public class SoftwareProductRepository
    {
        BitDatabaseEntities bitDB = new BitDatabaseEntities();
        public IEnumerable<BuildMetrics> GetBuildMetrics()
        {
            return bitDB.bit_sanity_results.Select(r => new BuildMetrics(...));
        }
    }
