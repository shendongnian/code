    public async void button1_Click(object sender, EventArgs e)
    {
      await this.ButtonClickHandlerAsync()
    }    
    
    // Unit test this
    public async Task ButtonClickHandlerAsync()
    {
            MyClass2 mc2 = new MyClass2();
            label1.Text = "Start";
            List<string> list = await mc2.GetInfosAsync("test123");
            label1.Text = "";
            list.ForEach(x => label1.Text += x + "\n");
    }
