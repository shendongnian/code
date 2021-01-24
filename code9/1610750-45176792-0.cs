    private void Form1_Load(object sender, EventArgs e)
    {
        string[] singleArray = File.ReadAllLines("path to your file");
        // alternatively, for testing:
        //string[] singleArray = {"http://www.google.com", "http://www.microsoft.com", "http://www.stackoverflow.com"};
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.RowCount = singleArray.Length;
        for (int i = 0; i < singleArray.Length; i++)
        {
            // create a new link label and set some properties
            LinkLabel linkLabel = new LinkLabel();
            linkLabel.Text = "I am link label #" + i;
            LinkLabel.Link linkLabelLink = new LinkLabel.Link();
            linkLabelLink.LinkData = singleArray[i];
            // tell the label to open a browser upon a click
            linkLabel.LinkClicked += (o, args) => System.Diagnostics.Process.Start(args.Link.LinkData as string);
            linkLabel.Links.Add(linkLabelLink);
            // add new link label to row i in colum 0
            tableLayoutPanel1.Controls.Add(linkLabel, 0, i);
        }
    }
