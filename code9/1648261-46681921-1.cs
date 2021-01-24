    public partial class Form1 : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public Form1()
        {
             string myFolder = Path.Combine(path, "Ausgabe");
             Directory.CreateDirectory(myFolder);
        }
