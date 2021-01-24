        public MainWindow()
        {
            InitializeComponent();
            var h1 = new Header()
            {
                Name = "Name0",
                Value = true,
                Names = new string[2] { "Name1", "Name2" }
            };
            var h2 = new Header()
            {
                Name = "Name1",
                Value = true,
                Names = new string[2] { "Name12", "Name22" }
            };
            addNewColumn(h1, "col1");
            addNewColumn(h2, "col2");
             
        }
        public class Header
        {
             public string Name { get; set; }
             public bool Value { get; set; }
             public string[] Names { get; set; }
        }
