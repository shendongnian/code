    private void Button1_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string[] indexes = btn.Tag.ToString().Split(',');
        //in indexes[0] you've got the i index and in indexes[1] the j index
        Console.WriteLine(indexes[0] + "," + indexes[1]);
    }
