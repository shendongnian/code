    private void Pocetna_forma_Load(object sender, EventArgs e)
    {
        SetUpTimer(new TimeSpan(20, 10, 00));
        Timer_bolovanje(new TimeSpan(20, 00, 00));
        Timer_godisnji(new TimeSpan(20, 05, 00));
    }
    void InTimerBolovanje_Tick()
    {
        if(dow == DayOfWeek.Sunday || dow == DayOfWeek.Saturday)
        {
            DoBolovanje_Thing()
        }
    }
    void InTimerGodisnji_Tick()
    {
        if(dow == DayOfWeek.Sunday || dow == DayOfWeek.Saturday)
        {
            Godisnji_Thing()
        }
    }
