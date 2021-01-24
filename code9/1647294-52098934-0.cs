		void _TsiMenu_Click(object sender, EventArgs e)
		{
			AdjustableMenu.Show(this, this.PointToClient(Cursor.Position), ToolStripDropDownDirection.Default);
			Application.DoEvents();
			if (AdjustableMenu.Visible == false)
				AdjustableMenu.Show(this, this.PointToClient(Cursor.Position), ToolStripDropDownDirection.Default);
		}
