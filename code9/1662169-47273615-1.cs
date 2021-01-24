    //First, separate out the this code into a function that accepts a file name and returns the values via the IEnumerable interface, rather than an array or list
    IEnumerable<int> ReadScores(string filename)
    { 
        //Use the `System.IO.File` class to make reading simpler
        // and use the linq functions to get this down to a single line of code:
        return File.ReadLines(filename).Select(l => int.Parse(l));
    }
    private void btnOpen_Click(object sender, EventArgs e)
    {
        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            //ToList() is optional, but it will force the data into memory, so we only need to go disk once
            var data = ReadScores(ofd.FileName).ToList();
            int total = data.Sum();
            int count = data.Count;
            float average = (float)total / (float)count;
        }
    }
