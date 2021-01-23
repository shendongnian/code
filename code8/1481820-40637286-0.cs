    public class ControllerHelper : IDisposable()
    {
        private UranusContext db = new UranusContext();
        public void Dispose()
        {
            if (this.db != null)
            {
                this.db.Dispose();
                this.db = null;
            }
            GC.SuppressFinalize(this);
        }
        public void DeleteChain(int? chainId)
        {
           // Do what you need to do, but don't Dispose()
           // nor use using, we want db to be functional
        }
        public void DeleteSheet(int? sheetId)
        {
           // Do what you need to do, but don't Dispose()
           // nor use using, we want db to be functional
        }
    }
