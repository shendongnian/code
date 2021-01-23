    private bool keyCombo1 = false;
    private bool keyCombo2 = false;
    
    private void textBox1_KeyDown(object sender, KeyEventArgs e) {
      if (e.Control) {
        if (e.Shift) {
          if (e.KeyCode == Keys.F) {
            keyCombo1 = true;
          }
          else {
            if (e.KeyCode == Keys.C && keyCombo1) {
              textBox2.AppendText("Key Combo 1 hit" + Environment.NewLine);
            }
            else {
              keyCombo1 = false;
            }
          }
        }
        else {
          // control only no-shift
          if (e.KeyCode == Keys.F) {
            keyCombo2 = true;
          }
          else {
            if (e.KeyCode == Keys.H && keyCombo2) {
              textBox2.AppendText("Key Combo 2 hit" + Environment.NewLine);
            }
            else {
              keyCombo2 = false;
            }
          }
        }
      }
      else {
        // no control key pressed
      }
    }
