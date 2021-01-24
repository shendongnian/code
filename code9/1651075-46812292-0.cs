     public static void RecepcionMensajes(TextBox textBox)
        {
            if (client.Connected == true)
            {
                try
                {
                    string fifo = Conexion.STR.ReadLine();
                    Queue mensajes = new Queue();
                    //Aquí se ponen en cola los mensajes que van llegando, utilizando el sistema FIFO.
                    mensajes.Enqueue(fifo);
                    string values = mensajes.Dequeue().ToString();
                    textBox.Invoke(new MethodInvoker(delegate () { textBox.AppendText("Exemys : " + values.Substring(2) + Environment.NewLine); })); 
