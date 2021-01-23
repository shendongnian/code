    IEnumerable<Ticket> result = _tickets
        // first remember the ticket and convert the MetaData
        // to either null or a SIFTEscalationMetadata
        .Select(t => new
        {
            Ticket = t,
            MetaData = t.Metadata as SIFTEscalationMetadata,
        })
        // now take only those tickets where the metadata is not null
        .Where(t => t.MetaData != null)
        // and select from the remaining tickets the Ids you want to check
        .Select(t => new
        {
            Ticket = t.Ticket,
            Ids = new IdType[]
            {
                t.MetaData.Address.Id,
                t.MetaDate.AddressEntered.Id,
                t.MetaData.CleanedAddress.Id,
            },
         })
         // now take only those items where the intersection of the Ids and 
         // addesses has any elements
         .Where(t => addess.Interset(t.Ids).Any())
         .Select(t => t.Ticket);
