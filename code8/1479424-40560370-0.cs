    public void NodeSelected(object sender, DiagramEventArgs e)
    {
        Node node = (e.Item as Node);
        string ders = ((Link_Map.Classes.Links)(((System.Windows.Controls.ContentControl)(node)).Content)).link;
        Console.WriteLine(ders);
    }
