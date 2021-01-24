    public Action<object, EventArgs> VCAction;
    
    btn.TouchUpInside += (s, e) =>
			{
				//VCAction.Invoke(s, e);
			};
