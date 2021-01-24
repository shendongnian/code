    private void readRegister()
    {
        //  Don't you want to do this if it's NOT connected?
        if (!modbusConnected)
        {
            modbusClient = new ModbusClient(comboBoxCOMPorts.SelectedItem.ToString());
