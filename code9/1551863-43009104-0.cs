    public class Main1
    {
        public static void Main()
        {
          var mainForm = new MainForm();
          mainForm.AddItemToListView("test");
        }
    }
    
    public class MainForm
    {
        public void AddItemToListView(string text)
        {
            listView1.Items.Add(text);  
        }
    }
