    // dataholder class
    public class MyDataHolder
    {
        public string UserName { get; set; }
        public int MyId { get; set; }
        public List<double> Whatever { get; set; }
        public DateTime CreatedOn { get; set; }
    }
 
    // form1
    public class Form1: Form
    {
        // a field with a reference to the dataholder
        private MyDataHolder _myData;
        public Form1()
        {
            // create the data
            _myData = new MyDataHolder();
            _myData.UserName = "Unknown";
            _myData.CreatedOn = DateTime.Now;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // create the form2 and pass the data
            using(Form2 form2 = new Form2(_myData))
                form2.ShowDialog();
        }
    }
    public class Form2 : Form
    {
        // a field with a reference to the dataholder
        private MyDataHolder _myData;
        public Form2(MyDataHolder myData)
        {
            // don't forget to assign it to the field
            _myData = myData;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // show the username
            MessageBox.Show(_myData.UserName);
        }
    }
