    private void button3_Click(object sender, EventArgs e)
    {
        System.Threading.Thread t = new System.Threading.Thread(()=>DoTheLoop());
        t.Start();
    }
