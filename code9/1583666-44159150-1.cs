    private async Task Test1()
    {
        listBox1.Items.Add($"{DateTime.Now:HH:mm:ss} - Start");
        await Task.Run(HardWorkTakesLongTime);
        
        listBox1.Items.Add($"{DateTime.Now:HH:mm:ss} - Work");
        
        await Task.Run(HardWorkTakesLongTime);
        
        listBox1.Items.Add($"{DateTime.Now:HH:mm:ss} - More Work");
        
        await Task.Run(HardWorkTakesLongTime);
        
        listBox1.Items.Add($"{DateTime.Now:HH:mm:ss} - stop");
    }
    void HardWorkTakesLongTime(){
        Thread.Sleep(2000);
    }
    
    
    // From a button click event or something like it
    btn_Click(){
    
        Test1();
    }
