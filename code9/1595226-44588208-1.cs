            private void newToolStripMenuItem_Click(object sender, EventArgs e)
            {
                FrmGeneral open = Application.OpenForms["FrmGeneral"] as FrmGeneral;
                if (open == null)
                {
                    FrmGeneral frm = new FrmGeneral();
                    frm.MdiParent = this;
                    frm.ListFill("General button clicked");
                    frm.Show();
                }
                else
                {
                    open.Activate();
                    if (open.WindowState == FormWindowState.Minimized)
                    {
                        open.WindowState = FormWindowState.Normal;
                    }
                }
            }
