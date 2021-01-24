    class ThreadSafeCalls
    {
        private object mLock = new object();
        private int lastRowAdded = -999;
    
        public int LastRowAdded
        {
            get {
                lock (mLock) {
                    return lastRowAdded;
                }
            }
            set {
                lock (mLock) {
                    lastRowAdded = value;
                }
            }
        }
    
        public void AddGridRow(DataGridView gv)
        {
            if (gv.InvokeRequired) {
                gv.BeginInvoke((MethodInvoker)delegate () {
                    LastRowAdded = gv.Rows.Add();
                });
            }
            else {
                LastRowAdded = gv.Rows.Add();
            }
        }
        public void AddGridCellData(DataGridView gv, int column, int rowID, string value)
        {
            if (gv.InvokeRequired) {
                gv.BeginInvoke((MethodInvoker)delegate () {
                    gv.Rows[rowID].Cells[column].Value = value + " "; 
                });
            } else {
                gv.Rows[rowID].Cells[column].Value = value;
            }
        }
    }
Replace all uses of tsc.lastRowAdded with tsc.LastRowAdded and it should work correctly consistently. Bear in mind that normal read-modify-write operations such as LastRowAdded++ and LastRowAdded-- are not thread safe because there's a window between the read and the write, reintroducing the cache problem. Frankly I would make LastRowAdded private and perform all mutations within ThreadSafeCalls, but with the aforementioned way you don't have to change much.
