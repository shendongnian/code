    public async Task<bool> AddTarefa(ListasPicking listaPickingAdd) {
        
        var response = await cliente.PutAsJsonAsync("api/ListasPicking/", listaPickingAdd);
        return response.IsSuccessStatusCode;        
    }
