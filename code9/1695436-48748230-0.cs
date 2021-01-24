    protected override void WndProc(ref Message m) {
                if((f2.IsDisposed || !f2.Visible)) {
                    foreach(var control in controlList) {
                        control.Enabled = true; // enable all controls or other logic
                    }
                }
                if(m.Msg == 0x18 && !f2.IsDisposed) { // notify dialog opens and double checks dialog's situation
                    foreach(var control in controlList.Where(ctrl => ctrl.Name != "button1")) {
                        control.Enabled = false; // disable except cancel button
                    }
                }
                base.WndProc(ref m);
            }
