    for (int i = 0; i < data.Devices.Length; i++){
    Button _button = new Button();
    _button.Size = new System.Drawing.Size(100, 55);
    _button.Text = data.Devices[i].Alias;
    _button.Name = "dynamicButton";
    _button.FlatStyle = FlatStyle.Flat;
    _button.Tag =	data.Devices[i].Alias + "|" + 
					data.Devices[i].DeviceId + "|" + 
					data.Devices[i].LastSeen + "|" + 
					data.Devices[i].OnlineState + "|" + 
					data.Devices[i].Description + "|" + 
					data.Devices[i].RemotecontrolId; 
					
    _button.Location = new System.Drawing.Point(x, y);
    x += 110;
    if (x > 1850)
    {
		y += 60;
        x = 30;
    }
	_button.Click += new EventHandler(bt_click);
    Controls.Add(_button);
    }
