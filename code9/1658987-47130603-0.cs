    private async void button5_Click(object sender, EventArgs e)
    {await Task.Run(() =>{
                Bitrate(listBox1);
                Bitrate(listBox2);
                Bitrate(listBox3);
            });
    }
     private async void Bitrate(List<...> list)
    {
        //turn listBox into List
        List<String> data = new List<String>(list.Items.Cast<String>());
        //do process for each item in the List
        Parallel.ForEach(data, (item) =>
        {
           System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "cmd.exe";
            ...............
         });}
