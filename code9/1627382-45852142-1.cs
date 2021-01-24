    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MainPage.StaticEvento.Add(new Evento { Minuto = "10", Segundo = "00", Icono = "", Accion = "Triple de", Equipo = " Visitante" });
        Frame rootFrame = Window.Current.Content as Frame;
        rootFrame.GoBack();
    }
