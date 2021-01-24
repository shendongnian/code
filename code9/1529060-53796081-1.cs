    string selector = SmartCardReader.GetDeviceSelector();
    DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(selector);
    foreach (DeviceInformation device in devices)
    {
        SmartCardReader reader = await SmartCardReader.FromIdAsync(device.Id);
    
        // For each reader, we want to find all the cards associated
        // with it.  Then we will create a SmartCardListItem for
        // each (reader, card) pair.
        IReadOnlyList<SmartCard> cards = await reader.FindAllCardsAsync();
    
        foreach (SmartCard card in cards)
        {
            SmartCardProvisioning provisioning = await SmartCardProvisioning.FromSmartCardAsync(card);
    
            SmartCardListItem item = new SmartCardListItem()
            {
                ReaderName = card.Reader.Name,
                CardName = await provisioning.GetNameAsync()
            };
    
            cardItems.Add(item);
        }
    }
