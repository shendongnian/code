    private void openPointsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "Text files|*.txt|All files|*.*";
        openFileDialog1.Title = "Open the Captured Packets";
        openFileDialog1.ShowDialog();
        if (openFileDialog1.FileName != "")
        {
            foreach (string line in System.IO.File.ReadLines(openFileDialog1.FileName).Take(100000))
            {
                var link = line.Split(null);
                textBox1.AppendText(link[0] + "         " + link[1] + "         " + link[2] + "         "+ link[3] + "\r\n");
                dataPt Temp = new dataPt(Convert.ToDouble(link[0]), Convert.ToDouble(link[1]), Convert.ToDouble(link[2]), Convert.ToDouble(link[3]));
                dataList.Add(Temp);
                ptDisplay.Items.Add(Temp.ToString());
            }
        }
    }
