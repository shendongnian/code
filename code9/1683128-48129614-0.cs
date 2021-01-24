    private void SubscribeMouseClicks(Control parentControl, MouseEventHandler eventHandler)
    {
        foreach (Control ctrl in parentControl.Controls)
        {
            if (ctrl.GetType() != typeof(Button))
            {
                ctrl.MouseUp += eventHandler;
                if (ctrl.HasChildren)
                {
                    SubscribeMouseClicks(ctrl, eventHandler);
                }
            }
        }
    }
