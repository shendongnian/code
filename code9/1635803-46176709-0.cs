    bool IsOpenFileDialog = false; // global variable to check if openfile opened
    
    private void button1_Click_1(object sender, EventArgs e) {
         IsOpenFileDialog = true; // button opens openfile dialog on click event
         openFileDialog1.ShowDialog(); // show it, it waits until dialog closed
         IsOpenFileDialog = false; // after closed set it to false
    }
    private void timer1_Tick(object sender, EventArgs e) {
         textBox1.Text += "Ticking! \n"; // added a textbox to show the ticking 
    }
    protected override void WndProc(ref Message m) {
          base.WndProc(ref m);
          if (m.Msg == 289) // check message loop
          {
             if (!timer1.Enabled && IsOpenFileDialog) {
          // if timer is not running already and button clicked to open openfiledialog
                timer1.Start(); // start timer
             }
          }
    }
