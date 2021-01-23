    [Route("api/Address/GetAllAsync")]
    [HttpGet]
    public async Task<IEnumerable<AddressModel>> GetAllAsync()
    {
        AddressService service = new AddressService(new DataContext());
        IEnumerable<Address> data = await service.GetAllAddressesAsync();
        var addressList = Mapper.Map<IEnumerable<AddressModel>>(data);
    
        return addressList;
    }
