	string position = "R1"; // string from your socket
	string ctlName = "pic_position_" + position.ToLower(); // build up control name from the received string
	Control match = this.Controls.Find(ctlName, true).FirstOrDefault(); // find the control
	if (match != null) // see if a match was found
	{
		match.Visible = true;
	}
