    public List<string> SDays = new List<string>(); // or whatever type     
  
            //  inside method
            String JSONstring = File.ReadAllText("\\USER\\Schedule\\Schedule.txt");
            RootObject p1 = JsonConvert.DeserializeObject<RootObject>(JSONstring);
            
            for (int a = i; a <= (i + 3); a++)
            {
                SDays.Add(p1.schedulePeriods[a].day);
                //and so on
            }
