    async Task refreshData() {
        this.IsBusy = true;
        bonosLista = await manager.GetAll();  //obtaining bonos from Server
        if (bonosLista != null) {
            if (bonosLista.Count() > 0) {
                BonosList.ItemsSource = bonosLista;
            } else {
                BonosList.IsVisible = false;
                BonosListMessage.IsVisible = true;
            }
        } else {
            await DisplayAlert("Error!", "Se ha producido un error en la conexión", "OK");
        }
        this.IsBusy = false;
    }
