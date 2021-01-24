	byte num;
	if (!byte.TryParse(last, out num))
    {
        System.Media.SystemSounds.Asterisk.Play();
        if (last.Length > 1)
    		zBox.Text = zBox.Text.Remove(last.Length - 1);
        else if (last.Length == 1)
        	zBox.Text = "";
    }
