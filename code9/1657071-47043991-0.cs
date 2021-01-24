        private XLWorkbook workbook;
        [OneTimeSetUp]
        public void Init()
        {
            // Make sure tests run on a deterministic culture
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            workbook = SetupWorkbook();
        }
