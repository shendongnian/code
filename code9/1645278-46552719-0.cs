    public partial class MainWindow : Window
    {
        private static object lockObj = new object(); //Add
...
    public List<string> getURLList()
      {
         List<string> urlList = new List<string>();
         for (int i = 0; i < AmazonUrlList.Count; i++)
         {
            Amazon url = new AmazonUrl();  // Add
            url = AmazonUrlList[i];        // Update
