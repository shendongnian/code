    foreach(var item in LBSerialAndColors.Items.OfType<COM>())
    {
        if (item.Name == CB_SelecComPort.Text)
        {
            item.Color = _colorPicker.SelectedColor.Value.R.ToString("X2") + _colorPicker.SelectedColor.Value.G.ToString("X2") + _colorPicker.SelectedColor.Value.B.ToString("X2") + _colorPicker.SelectedColor.Value.A.ToString("X2"); //R G B A                    
            _SerialPortsColorReadWriteXML.WriteXML();
            _SerialPortsColorReadWriteXML.ReadXML();
            MessageBox.Show("Serial Port and Color has been updated");
            return;
        }
    }
