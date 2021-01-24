    // add a trailing '.' so we can match the start of the excelIP
    string octets = ("10.2.30."); 
    var match = false;
            
    for (int i = 0; i < xlRange.Rows.Count; i++)
    {
        // Get the IP address portion of the CIDR string
        var cellIP = xlWorksheet.Cells[i + 1, 1].Value.Split('/')[0];
        IPAddress excelIP;
        // If cellIP starts with the octets string and it's a valid IP address...
        if (cellIP.StartsWith(octets) && IPAddress.TryParse(cellIP, out excelIP))
        {
            match = true;
            Console.Write(excelIP.ToString());
            Console.WriteLine(" -This id was found");
        }
    }
