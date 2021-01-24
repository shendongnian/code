    public class MyItem
    {
        public int ParentClassCode { get; set; }
        public MyItem(int parentClassCode)
        {
            ParentClassCode = parentClassCode;
        }
        private void MyMethod()
        {
            // Now we can refer to ParentClassCode
        }
    }
