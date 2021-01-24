    public class AssemblyItem
    {
    public string Name {get;set;}
    public string FullPath {get;set;}
    }
    private void materialFlatButton3_Click_1(object sender, EventArgs e)   
    {
      // Use your existing code to get the selection of DLLs
      List<AssemblyItem> items = new List<AssemblyItem>();
      foreach (string fileName in fullFileName)
      {
      items.Add(new AssemblyItem() 
         { 
          Name = System.IO.Path.GetFileName(fileName),
          FullPath = fileName
         };
       }
      listBox1.DataSource = items;
      listBox1.DisplayMember = "Name";
      listBox1.ValueMember = "FullPath";
      listBox1.BindData();
