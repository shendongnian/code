    public void AddSerial(string machineId)
    {
        using (var context = new MyDbContext())
        {
            int max = context.SerialNumbers
                .Where(sn => sn.MachineId  == machineId)
                .Max(sn =>(int?)sn.Snr) ?? 0; //Extra clauses added after edit
            max++;
            context.SerialNumbers.Add(new SerialNumber{ MachineId = machineId, Snr = max});
            context.SaveChanges();
        }
    }
