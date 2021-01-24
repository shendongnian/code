    public void ShowPopUp(Func<IPopUp> factoryFuncPopUp)
	{
		if (PopUpShowed != null) {
			PopUpShowed.Close ();
		}
		IPopUp popUp = factoryFuncPopUp();
		popUp.Show ();
	}
