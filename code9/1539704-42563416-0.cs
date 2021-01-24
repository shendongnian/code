    namespace WindowsFormsApplication1
    {
        class ListBoxAdder
        {
            ListBox listBox;
            public ListBoxAdder (ListBox listBox)
            {
                this.listBox = listBox;
            }
            public void Testing()
            {
                listBox.Items.Add("TEST");
            }
        }
    }
