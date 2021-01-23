    public void ChangeDate(Contract contract, DateRange dates)
    {
        if (contract.Id != this.ContractId)
            throw new ArgumentException("wrong contract", "contract");
  
        if (!contract.AreSaleDatesValid(dates))
            throw new ArgumentException("wrong dates", "dates");
        this.Dates = dates;
    }
