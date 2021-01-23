    private void boxButton_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        DataBox box = btn.Parent as DataBox;
        if (box != null)
            Console.WriteLine(box.rowID + " clicked");
    }
