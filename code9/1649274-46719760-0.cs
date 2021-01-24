    private async void timerMesas_Tick(object sender, EventArgs e)
    {
        string T1 = await Task.Run<string>(() => oClasePublica.testConeccion());
        if (T1 == "true")
        {
            btnEstado.Image = new System.Drawing.Bitmap(TOUCHREST.Properties.Resources.Status_32x32);
        }
        else
        {
            btnEstado.Image = new System.Drawing.Bitmap(TOUCHREST.Properties.Resources.Warning_32x32);
        }
    }
