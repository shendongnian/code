    private void readButton_Click(object sender, EventArgs e)
    {
        int counter = 0;
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Harra\Documents\Visual Studio 2017\Projects\File Reader\Sales.txt");
        double dblAdd = 0;
        while ((line = file.ReadLine()) != null)
        {
            displayListBox.Items.Add(line);
            dblAdd += Convert.ToDouble(line);
            counter++;
        }
        totalTextBox.Text = string.Format("{0:F}", dblAdd);
