    private void btn_generate_Click(object sender, EventArgs e) {
        txt_generate.Text = Generate();
    }
    private static Random _random = new Random();
    public string Generate() 
    {
        return string.Join("-", Enumerable.Range(0, 4).Select(i => GetLetter()));
    }
    public string GetLetter() 
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Range(0, 4).Select(i => chars[_random.Next(chars.Length)]).ToArray());
    }
