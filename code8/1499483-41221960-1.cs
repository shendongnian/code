    public void AddSerial(string machineId)
    {
        using (var context = new MyDbContext())
        {
            int max = context.SerialNumbers.Max(sn => sn.Snr ?? 0);
            max++;
            context.SerialNumbers.Add(new SerialNumber{ MachineId = machineId, Snr = max});
            context.SaveChanges();
        }
    }
