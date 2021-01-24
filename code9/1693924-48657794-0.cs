    protected override void Dispose(bool disposing)
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                base.Dispose(disposing);
            }
