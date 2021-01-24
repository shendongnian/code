    public class SomeClass
    {
        private bool bProcessing;
        private Action DoImageProcessing; // bProcessing is out of scope here
        public SomeClass()
        {
            DoImageProcessing = () =>
            {
                bProcessing = true; // bProcessing is now in scope
                GetPoints();
                bProcessing = false;
            } 
        }
        private void GetPoints()
        {
            // implementation of GetPoints()...
        }
    }
