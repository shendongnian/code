        private Object objLockVar = new Object();
        void newData()
        {
            // ...code...
            lock (objLockVar)
            {
                //clear x
                //put new data in it
                // other code considered part of the "atomic" operation
            }
            // ...more code...
        }
        private void btRead_Click(object sender, EventArgs e)
        {
            lock (objLockVar)
            {
                // read x
            }
            // ...more code...
        }
