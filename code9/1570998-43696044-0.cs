    string ipname = "IP-ADDRESS-";
    var ipAddrRegex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", RegexOptions.Compiled);
    int lineNum = 1;
    int addressNum = 1;
    var foundAddresses = new Dictionary<string, string>();
    string line;
    using (StreamReader sr = new StreamReader(@"ips.txt"))
    {
        while ((line = sr.ReadLine()) != null)
        {
            foreach (var match in ipAddrRegex.Matches(line).Cast<Match>())
            {
                string addressName;
                if (!foundAddresses.TryGetValue(match.Value, out addressName))
                {
                    addressName = ipname + addressNum.ToString();
                    foundAddresses.Add(match.Value, addressName);
                    addressNum++;
                }
                Console.WriteLine("Line {0}: {1} ---> {2}", lineNum, match.Value, addressName);
            }
            lineNum++;
        }
    }
