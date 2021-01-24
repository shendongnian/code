    ControlCollection controls = this.FindControl("cphHead").Controls;
    foreach (Control control in controls)
    {
        if (control.GetType() == typeof(LiteralControl))
        {
            ((LiteralControl)control).Text = "Change TEXT";
            break;
        }
    }
