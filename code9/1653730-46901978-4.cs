    private void btAlta_Click(object sender, RoutedEventArgs e)
    {
        String res;
        if (Campos())
        {
            res = Interaction.InputBox("Está por realizar un alta, para confirmarla escriba su contraseña:", "Confirmación");
            // I would suggest to add this line of code
            if(UserA == null)
            {
                UserA = Menu.User;
            }
            
            if (res.Equals(UserA.Pwd.ToString()))
            {
                altaUser(tbLogin, tbPass, tbNombre, Activo, Admin, Reportes);
                MessageBox.Show("Usuario agregado satisfactoriamente");
                cambio = true;
            }
            else MessageBox.Show("Contraseña incorrecta intente de nuevo");
        }
        else
            MessageBox.Show("Existe algún error en los campos o quedaron vacíos");
    }
