    // Declare the myIp variable
    string myIp = "";
 
    if (osVer.StartsWith("10")) 
    {
     MessageBox.Show("Windows 10");
    
    // Make sure "myIP" isn't null before trying to use it (here, and on other places where you use it)
    if(!string.IsNullOrWhiteSpace(myIp))
    myIP = Dns.GetHostEntry(HostName).AddressList[2].ToString(); // Get the IP
    }
    else if (osVer.StartsWith("6"))
    {
    MessageBox.Show("Win7!");
    
    // Make sure "myIP" isn't null before trying to use it (here, and on other places where you use it)
    if(!string.IsNullOrWhiteSpace(myIp))
    myIP = Dns.GetHostEntry(HostName).AddressList[3].ToString(); // Get the IP
    
    }
    else {
     // Make sure "myIP" isn't null before trying to use it (here, and on other places where you use it)
    if(!string.IsNullOrWhiteSpace(myIp))
     myIP = "?";
