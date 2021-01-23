    namespace WindowsFormsApplication2
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            string[] test = new string[] { "Test Name","Test Description","Test Category"};
            MyClass oClass = new MyClass();
            oClass.MyArray = test;
            Console.WriteLine("Name: " + oClass.MyName + Environment.NewLine +
                "Description: " + oClass.MyDescription + Environment.NewLine +
                "Category: " + oClass.MyCategory);
        }
    }
     class MyClass
    {
        private string _myName;
        public string MyName
        {
            get { return _myName; }
            set { _myName = value; }
        }
        private string _myDesc;
        public string MyDescription
        {
            get { return _myDesc; }
            set { _myDesc = value; }
        }
        private string _myCat;
        public string MyCategory
        {
            get { return _myCat; }
            set { _myCat = value; }
        }
        private string[] _myArr;
        public string[] MyArray
        {
            get { return _myArr; }
            set {
                _myArr = value;
                MyName = value[0];
                MyDescription = value[1];
                MyCategory = value[2];
            }
        }
    }
