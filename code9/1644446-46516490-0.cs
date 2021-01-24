    private void timer1_Tick(object sender, EventArgs e)
    {
        if (timer1.Enabled == true)
        {
            // Checking if we entered Dragon's B10
            if (inDungeon == false)
            {
                GoToDungeon();
            }
    
            // Starting battle
            autoSumPoint = AutoIt.AutoItX.PixelGetColor(2078, 61); // 0xF1EECF
            if (autoSumPoint == 0xF1EECF)
            {
                StartBattle();
            }
            else
            {
                GoToDungeon();
            }
    
            // Starting auto-play
            autoSumPoint = AutoIt.AutoItX.PixelGetColor(2296, 969); // 0xFFFFFF
            if (autoSumPoint == 0xFFFFFF)
            {
                AutoCheck();
            }
    
            // Starting battle
            autoSumPoint = AutoIt.AutoItX.PixelGetColor(2755, 489); // 0xF1EECF
            if (autoSumPoint == 0xF1EECF)
            {
                PauseCheck();
            }
    
            // Checking for defeat
            if (defeatChecked == false)
            {
                DefeatCheck();
            }
    
            // Checking for defeat
            if (defeatChecked == false)
            {
                DefeatCheck();
            }
    
            // Checking for victory
            if (victoryChecked == false)
            {
                VictoryCheck();
            }
    
            // Checking for replay
            autoSumPoint = AutoIt.AutoItX.PixelGetColor(2602, 587); // 0xF3C761
            if (autoSumPoint == 0xF3C761)
            {
                ReplayCheck();
            }
    
            // Checking for refill
            if (energyRefilled == false)
            {
                RefillCheck();
            }
        }
        System.Threading.Thread.Sleep(1000)//causes it to wait 1 second after each tick before the next one to reduce CPU usage
    }
