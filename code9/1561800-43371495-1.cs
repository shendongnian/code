    bool interactiveMode = (bool) Dts.Variables["System::InteractiveMode"].Value;
    if (interactiveMode)
    {
        // UI code here
        MessageBox.Show("Something happened");
    }
