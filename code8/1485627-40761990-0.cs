    private void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;
    
            var source = Encoding.Unicode;
            var target = Encoding.UTF8;
    
            var sBytes = source.GetBytes(e.Data);
    
            var tString = Encoding.UTF8.GetString(sBytes);
            Console.WriteLine(tString);
        }
