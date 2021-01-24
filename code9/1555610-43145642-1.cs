    var match = false;
    string octets = ("10.2.30");
    string[] octetsToMatch = octets.Split('.');
    for (int i = 0; i < xlRange.Rows.Count; i++)
    {
        // Get the IP address portion of the CIDR string
        var cellIP = xlWorksheet.Cells[i + 1, 1].Value.Split('/')[0];
        IPAddress excelIP;
        if (IPAddress.TryParse(cellIP, out excelIP))
        {
            // Compare the first octets of the IP address with our octetsToMatch
            if (octetsToMatch.SequenceEqual(cellIP.Split('.').Take(octetsToMatch.Length)))
            {
                match = true;
                Console.Write(excelIP.ToString());
                Console.WriteLine(" -This id was found");
            }
        }
    }
