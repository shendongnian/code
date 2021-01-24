    private void winAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upload objWA = new Upload();
            objWA.MdiParent = this;
            objWA.Show();
            //objWA.WindowState = FormWindowState.Maximized;
        }
        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports objUI = new Reports();
            objUI.MdiParent = this;
            objUI.Show();
			DisposeAllButThis(Form objUI);
            //objUI.WindowState = FormWindowState.Maximized;
        }
		public void DisposeAllButThis(Form form)
		{
			foreach (Form frm in this.MdiChildren)
			{
			    if (frm.GetType() == form.GetType() 
			        && frm != form)
			    {
			        frm.Dispose();
			        frm.Close();
			    }
			}
		}
