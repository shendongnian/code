    class Menu { 
       ...
       public ServerGUI ServerGui {get; set;}
       private void button1_Click(object sender, EventArgs e)
       {
            ServerGui.close();
       }
       private void button2_Click(object sender, EventArgs e)
       {
            ServerGui.send(textBox1.Text);
       }
