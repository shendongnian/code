    public partial class MyForm : Form
    {
        //So whenever you change the filename, you write it once, 
        //everyone will be updated
        private const string ColumnOrderFileName = "ColumnOrder.bin";
        //To prevent saving the data when we don't want to
        private bool refreshing = false;
        ... // the rest of your class
