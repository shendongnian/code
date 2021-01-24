    private void SetCurrentStartPositon(object sender, EventArgs e)
    {
        // Get the control that invoked this event
        IMyControl senderControl   = (IMyControl)sender;
        senderControl.SomeProperty = DummyTextBox.Text;
    }
