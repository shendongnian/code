        //Polling response from URL
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader resStream = new StreamReader(response.GetResponseStream());
        //Parsing response to separate out each donation
        JObject ParsedJson = JObject.Parse(resStream.ReadToEnd());
        var TransactionArray = ParsedJson["donations"].Children();
        //Array to store parsed results into usable format
        List<DonationsJSON> TransArray = new List<DonationsJSON> { };
        foreach (object Transaction in TransactionArray)
        {
            // clean up parsed string and remove Anonymous ID string
            string DonationString = Transaction.ToString().Replace("\r\n", "");
            DonationString = DonationString.Substring(DonationString.IndexOf(':') + 1);
            // Deserializing string into Donation class and adding to List
            DonationsJSON TX = JsonConvert.DeserializeObject<DonationsJSON>(DonationString);
            TransArray.Add(TX);
        }
