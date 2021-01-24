        if (!double.TryParse(_txStaticPressureUpdate.Text.Trim(), out staticPressure))
        {
            txSystemMessage.Text = "Field 'Static Pressure' has an invalid value.";
            txSystemMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }
