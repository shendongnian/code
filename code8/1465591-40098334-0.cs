    public class Form2
    {
        private static string labelPath;
        private static string objectPath;
        private static string path;
        public Form2()
        {
            InitializeComponent();
            setPaths();
            current = this;
            instantiateNumUpDown();
            System.IO.File.WriteAllText(Form2.labelPath, " ");
        }
        public static void setPaths()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            path = Path.Combine(systemPath, "TextDynamic.txt");
            labelPath = Path.Combine(systemPath, "currentLabel.txt");
            objectPath = Path.Combine(systemPath, "object.txt");
        }    
    }
