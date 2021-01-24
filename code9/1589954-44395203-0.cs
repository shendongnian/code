	public void ClearControls(Control cntr)
	{
		foreach (Control control in cntr.Controls)
		{
			if (control is SpellBox)
			{
				control.Text = "";
			}
			else if(control.HasChildren)
			{
				ClearControls(control);
			}
		}
	}
