    public void AddSerial(string machineId)
    {
        using (var context = new MyDbContext())
        {
            int max = context.SerialNumbers.Where(sn => sn.MachineId  == machineId).Max(sn => sn.Snr ?? 0); //Where clause added after edit
            max++;
            context.SerialNumbers.Add(new SerialNumber{ MachineId = machineId, Snr = max});
            context.SaveChanges();
        }
    }
