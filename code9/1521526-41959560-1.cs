         protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
               foreach (Form frm in Application.OpenForms)
               {
                 frm.WindowState = FormWindowState.Normal;
                 frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                 frm.Bounds = Screen.PrimaryScreen.Bounds;
                }
            }
