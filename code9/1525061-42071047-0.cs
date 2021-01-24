    bool result = await WriteSubmitDropOff(ShipGroup.id);
    private async Task<bool> WriteSubmitDropOff(int id)
    {
        try
        {
            ServiceLocal.Service1Client client = new ServiceLocal.Service1Client();
            await client.SubmitDropOffAsync(id);
            await client.CloseAsync();
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }
