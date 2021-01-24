    public async Task<string> GetAddressAsync(IAddressPath addressPath, bool isPublicKey, bool display, AddressType addressType, InputScriptType inputScriptType, string coinName)
    {
        try
        {
            var path = addressPath.ToArray();
    
            if (isPublicKey)
            {
                var publicKey = await SendMessageAsync<PublicKey, GetPublicKey>(new GetPublicKey { CoinName = coinName, AddressNs = path, ShowDisplay = display, ScriptType = inputScriptType });
                return publicKey.Xpub;
            }
            else
            {
                switch (addressType)
                {
                    case AddressType.Bitcoin:
    
                        //Ultra hack to deal with a coin name change in Firmware Version 1.6.2
                        if ((Features.MajorVersion <= 1 && Features.MinorVersion < 6) && coinName == "Bgold")
                        {
                            coinName = "Bitcoin Gold";
                        }
    
                        return (await SendMessageAsync<Address, GetAddress>(new GetAddress { ShowDisplay = display, AddressNs = path, CoinName = coinName, ScriptType = inputScriptType })).address;
    
                    case AddressType.Ethereum:
    
                        var ethereumAddress = await SendMessageAsync<EthereumAddress, EthereumGetAddress>(new EthereumGetAddress { ShowDisplay = display, AddressNs = path });
    
                        var sb = new StringBuilder();
                        foreach (var b in ethereumAddress.Address)
                        {
                            sb.Append(b.ToString("X2").ToLower());
                        }
    
                        var hexString = sb.ToString();
    
                        return $"0x{hexString}";
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        catch (Exception ex)
        {
            Logger?.Log("Error Getting Trezor Address", LogSection, ex, LogLevel.Error);
            throw;
        }
    }
