    StringBuilder sb = new StringBuilder();
    foreach(string line in File.ReadLines(openFileDialog1.FileName))
    {
        link = line.Split;
        sb.AppendLine(link[0] + "         " + link[1] + "         " + link[2] + "         "+ link[3]));
        dataPt Temp = new dataPt(Convert.ToDouble(link[0]), Convert.ToDouble(link[1]), Convert.ToDouble(link[2]), Convert.ToDouble(link[3]));
        dataList.Add(Temp);
        ptDisplay.Items.Add(Temp.ToString());
    }
    textBox1.AppendText(sb.ToString());
