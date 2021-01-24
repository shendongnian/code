    public void RunJobs()
    {
        ISchedulerFactory schfack = new StdSchedulerFactory();
        IScheduler scheduler = schfack.GetScheduler();
        CanliMaclariGetir(scheduler);
        // ...your other jobs
    }
    private void CanliMaclariGetir(IScheduler scheduler)
    {
        try
        {
            IJobDetail jobdetay = JobBuilder.Create<CanliMaclar>()
                .WithIdentity("canlimacgetir")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithSimpleSchedule(s => s.WithIntervalInSeconds(canlimacgetir).RepeatForever()).StartAt(g_canlimacgetir).Build();
            scheduler.ScheduleJob(jobdetay, trigger);
            scheduler.Start();
            Log log = new Log()
            {
                Name = "CanliMaclariGetir Görev Emri",
                Description = "CanliMaclariGetir Görev Emri Verildi.",
                Start = DateTime.Now,
                Finish = DateTime.Now,
                TotalMilliSecond = 0,
                Type = 6
            };
            DbWork db = new DbWork();
            db.LogEkle(log);
        }
        catch (Exception ex)
        {
            string h_mesaj = ex.Message.ToString();
            string icerik = "";
            if (ex.InnerException != null) { icerik = ex.InnerException.ToString(); }
            string h_yer = ex.StackTrace.ToString();
            dal.HataEkle("", "Gorevler Katmanı > Gorev_Zamanlayici.cs", "CanliMaclariGetir()", DateTime.Now, h_mesaj, icerik, h_yer);
        }
    }
