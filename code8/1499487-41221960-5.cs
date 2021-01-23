    public void AddSerial(string machineId)
    {
        using (var context = new MyDbContext())
        {
            int max = context.SerialNumbers
                .Where(sn => sn.MachineId  == machineId)
                .Select(sn => sn.Snr)
                .DefaultIfEmpty(0)
                .Max(); //Extra clauses added after edit
            max++;
            context.SerialNumbers.Add(new SerialNumber{ MachineId = machineId, Snr = max});
            context.SaveChanges();
        }
    }
