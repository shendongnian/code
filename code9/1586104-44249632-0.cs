        int cant;
       cant = command.ExecuteNonQuery();
        sql.Close(); //Move it here.
        if (cant == 1)
        {
            label4.Text = "";
            label5.Text = "";
            MessageBox.Show("Se ha eliminado");
        }
        else
        {
            MessageBox.Show("No existe un artículo con el código ingresado");
        }
        button2.Enabled = false;
