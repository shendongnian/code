    using System.Windows.Forms;
---
    private Timer click;
    private Int16 testCounter;
    
    private void Form1_Load(object sender, EventArgs e) {
        testCounter = 0;
    
        click = new Timer();
        click.Interval = 1000;
        click.Tick += new EventHandler(click_Tick);
    
        this.MouseDown += new MouseEventHandler(Loop_MouseDown);
        this.MouseUp += new MouseEventHandler(Loop_MouseUp);
    }
    private void Loop_MouseDown(object sender, MouseEventArgs e) {
        if(e.Button == MouseButtons.Left) {
            click.Start();
        }
    }
    private void Loop_MouseUp(object sender, MouseEventArgs e) {
        if(e.Button == MouseButtons.Left) {
            click.Stop();
        }
    }
    
    private void click_Tick(object sender, EventArgs e) {
        testCounter++;
    }
