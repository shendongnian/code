    public async Task<DataTable> GetDataAsync()
    {
        var dt = new DataTable();
        var cn = @"Your Connection String";
        var cmd = @"SELECT Field1 FROM Table1";
        var da = new SqlDataAdapter(cmd, cn);
        await Task.Run(() => { da.Fill(dt); });
        return dt;
    }   
    private async void Form1_Load(object sender, EventArgs e)
    {
        var data = await GetDataAsync();
        this.ListBox1.DataSource = data;
        this.ListBox1.DisplayMember= "Field1";
    }
