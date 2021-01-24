    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        Random rand = new Random();
        for (int i = 0; i <= 10; i++)
        {
            listBox1.Items.Add(rand.Next(0, 10));
        }
    }
    private void label1_Click(object sender, EventArgs e)
    {
        string[] strArray = new string[listBox1.Items.Count];
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            strArray[i] = listBox1.Items[i];
        }
        label1.Text = "Coppied items"; 
    }
