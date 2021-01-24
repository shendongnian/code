    private void SetCurrentStartPositon(object sender, EventArgs e)
    {
        // Get the control that invoked this event
        MyControlBase senderControl = (MyControlBase)sender;
        senderControl.SomeProperty  = DummyTextBox.Text;
    }
