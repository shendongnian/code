        public class TestableDPSContext : DBModel.DPSContext
        {
            public TestableDPSContext(DbConnection connection)
                : base(connection)
            {
            }
            protected override void Dispose(bool disposing)
            {
                // Do nothing
            }
            public void RealDispose(bool disposing)
            {
                // Invoke real dispose
                base.Dispose(disposing);
            }
        }
        [TearDown]
        public void FinishTest()
        {
            _dbEntities.RealDispose(false);
        }
