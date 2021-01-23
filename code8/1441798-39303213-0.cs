    private void SetColor(StatusBox sb, Color col)
    {
       if (sb.InvokeRequired)
	{	
		SetTextCallback d = new SetTextCallback(SetColor);
		this.Invoke(d, new object[] { col});
	}
	else
	{
		sb.Color = col;
	}
     }
