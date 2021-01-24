	private void CbOnCheckedChanged_1(object sender, EventArgs eventArgs)
	{
	    SetScrollBarValue(this.cb1, this.scrjoint1)
	}
	private void CbOnCheckedChanged_2(object sender, EventArgs eventArgs)
	{
	    SetScrollBarValue(this.cb2, this.scrjoint2)
	}
    ....
    private static void SetScrollBarValue(CheckBox cb, ScrollBar sb)
    {
        if (cb.Checked)
        {
            sb.Value = 0;
            sb.Enabled = false;
        }
        else sb.Enabled = true;
    }
