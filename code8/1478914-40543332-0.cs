    public Form1()
    {
       InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
       m_Grid.AllowUserToOrderColumns = true;
       SetDisplayOrder();
    }
    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
       CacheDisplayOrder();
    }
    private void CacheDisplayOrder()
    {
       IsolatedStorageFile isoFile =
          IsolatedStorageFile.GetUserStoreForAssembly();
       using (IsolatedStorageFileStream isoStream = new
          IsolatedStorageFileStream("DisplayCache", FileMode.Create,
             isoFile))
       {
          int[] displayIndices =new int[m_Grid.ColumnCount];
          for (int i = 0; i < m_Grid.ColumnCount; i++)
          {
             displayIndices[i] = m_Grid.Columns[i].DisplayIndex;
          }
          XmlSerializer ser = new XmlSerializer(typeof(int[]));
          ser.Serialize(isoStream,displayIndices);
       }
    }
    private void SetDisplayOrder()
    {
       IsolatedStorageFile isoFile =
          IsolatedStorageFile.GetUserStoreForAssembly();
       string[] fileNames = isoFile.GetFileNames("*");
       bool found = false;
       foreach (string fileName in fileNames)
       {
          if (fileName == "DisplayCache")
             found = true;
       }
       if (!found)
          return;
       using (IsolatedStorageFileStream isoStream = new
          IsolatedStorageFileStream("DisplayCache", FileMode.Open,
             isoFile))
       {
          try
          {
             XmlSerializer ser = new XmlSerializer(typeof(int[]));
             int[] displayIndicies =
                (int[])ser.Deserialize(isoStream);
             for (int i = 0; i < displayIndicies.Length; i++)
             {
                m_Grid.Columns[i].DisplayIndex = displayIndicies[i];
             }
          }
          catch { }
        }
    }
}
