            Control.ControlCollection f3_ctrls;
            //Case 1
            Form3 f3 = new Form3();            
            f3.Show();
            f3_ctrls = f3.Controls;
            //Case 2
            f3_ctrls = (Application.OpenForms["Form3"]).Controls;
            foreach (Control ctrl in f3_ctrls)
            {
                if ((ctrl is Button) && ctrl.Tag.Equals("myTag"))
                {
                    ctrl.BackColor = Color.White;
                }
            }
