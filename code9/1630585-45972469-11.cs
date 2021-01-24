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
        public void AddGridCellData(DataGridView gv, int column)
        {
            if (gv.InvokeRequired) {
                gv.BeginInvoke((MethodInvoker)delegate () {
                    var lastRow = LastRowAdded;
                    gv.Rows[lastRow].Cells[column].Value = lastRow + " "; 
                });
            } else {
                gv.Rows[rowID].Cells[column].Value = value;
            }
        }
    }
