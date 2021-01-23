    public UserControl1() {
      InitializeComponent();
      mouseTimer.Interval = 16;
      mouseTimer.Tick += mouseTimer_Tick;
      mouseTimer.Enabled = true;
    }
    private void mouseTimer_Tick(object sender, EventArgs e) {
      if (this.ActiveControl != null && this.ActiveControl.Equals(textBox1)) {
        if (MouseButtons != MouseButtons.None) {
          if (!textBox1.ClientRectangle.Contains(textBox1.PointToClient(MousePosition))) {
            if (this.ParentForm != null) {
              this.ParentForm.ActiveControl = null;
            } else {
              this.ActiveControl = null;
            }
          }
        }
      }
    }
