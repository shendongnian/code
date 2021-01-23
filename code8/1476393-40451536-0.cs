    public void Fill()
    {
       Thread.Sleep(5000);
    
       Action doUIWork = () => 
       {
          ComboBox1.Items.Add(1);
          ComboBox1.Items.Add(2);
          ComboBox1.Items.Add(3);
          ComboBox1.Items.Add(4);
          ComboBox1.Items.Add(5);
          ComboBox1.Items.Add(6);
          ComboBox1.Items.Add(7);
       };
    
       this.Invoke(doUIWork);
    }
