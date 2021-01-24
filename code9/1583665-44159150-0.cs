    private async Task Test1()
    {
        listBox1.Items.Add($"{DateTime.Now:HH:mm:ss} - Start");
        await Task.Delay(TimeSpan.FromMilliseconds(1000));
        
        listBox1.Items.Add($"{DateTime.Now:HH:mm:ss} - Work");
        
        await Task.DelayTimeSpan.FromMilliseconds(1000);
        
        listBox1.Items.Add($"{DateTime.Now:HH:mm:ss} - More Work");
        
        await Task.DelayTimeSpan.FromMilliseconds(1000);
        
        listBox1.Items.Add($"{DateTime.Now:HH:mm:ss} - stop");
    }
    
    
    // From a button click event or something like it
    btn_Click(){
    
        Test1();
    }
