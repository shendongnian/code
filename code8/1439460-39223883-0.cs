	private void PickComponent()
    {
		Component c1 = null;
	
		while (c1 == null)
		{
			TSMUI.Picker myPicker1 = new TSMUI.Picker();
			c1 = myPicker1.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_OBJECT) as Component;
			if (c1 == null)
			{
				MessageBox.Show("Please select a component.");
			}
		}
	}
