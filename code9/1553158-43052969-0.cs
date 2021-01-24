    bool foundIP = false;
    IPAddress excelIP;
    for (int i = 0; i < xlWorksheet.Rows.Count; i++)
    {
        if (IPAddress.TryParse(xlWorksheet.Cells[i + 1, 1].Value.ToString(), out excelIP))
        {       
            // Compare the IP address we found with the one we're looking for                 
            if (excelIP.Equals(addr))
            {
                foundIP = true;
                break;   // Exit the for loop since we found it
            }                
        }
    }  
    if (foundIP)
    {
        Console.WriteLine("Found the IP address!");
        // If you need to do something with the IP, you can use either excelIP
        // or addr, since they are both the same at this point
    }
    else
    {
        Console.WriteLine("Found the IP address!");
    }
