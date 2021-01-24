    using System.Reflection;
    bool doubleBuffered = true;
    typeof(DataGridView).InvokeMember("DoubleBuffered", 
        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, 
        null, dataGridView1, new object[] { doubleBuffered });
