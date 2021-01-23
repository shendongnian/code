    public Control findControlbyName(String name, Control parent){
		foreach (Control ctr in parent.Controls)
		{
			if (ctr.Name.Equals(name)) return ctr;
			else return findControlbyName(name, ctr);
		}
		return null;
	}
