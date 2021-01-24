    namespace TestForm
    {
        class TestClass
        {
            public TestClass()
            {
                DataGridView tmp = new DataGridView();
                GetVertElementasList getList = new GetVertElementasList();
                var TEST = getList.vertList(tmp);
    
                MessageBox.Show(TEST[5].p2.ToString());
            }
        }
    }
