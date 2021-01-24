    public async void button2_Click(object sender, EventArgs e)
    {
        await Proceso1();
    }
    
    private async Task Proceso1()
    {
        for (int i = 1; i < 101; i++)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Actualizar1(i);
            });
            await Task.Delay(1000);
        }
    }
    
    private void Actualizar1(int valor)
    {
        ProgressBar1.Value = valor;
    
        int incremento = valor % 4;
        switch (incremento)
        {
            case 1: lblMensaje.Text = "Estamos procesando ."; break;
            case 2: lblMensaje.Text = "Estamos procesando .."; break;
            case 3: lblMensaje.Text = "Estamos procesando ..."; break;
            default: lblMensaje.Text = "Estamos procesando ...."; break;
        }
    }
