            foreach (Control ctrl in Controls)
            {
                if (ctrl is GroupBox)
                {
                    foreach (Control sub_ctrl in ctrl.Controls)
                    {
                         CheckControl(sub_ctrl);
                    }
                }
                else
                {
                     CheckControl(ctrl);
                }
            }
