    public Action<int> OnSetTotalCost;
    private void button1_Click(object sender, EventArgs e)
    {
      Form1 ytr = new Form1();
      var talCost = int.parse(textBox3.Text);
      if(OnSetTotalCost != null) OnSetTotalCost(talCost);
    }
