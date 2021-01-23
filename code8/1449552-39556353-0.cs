    public List<TimeSlots> TimeSlotList
    {
        get
        {
            List<TimeSlots> result = new List<TimeSlots>();
            string[] parts = _TimeSlots.Split(new char[] { '|'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string slotData in parts)
            {
                string[] data = slotData.Split(',');
                result.Add(new TimeSlots()
                {
                    StartSlot = data[0],
                    EndSlot = data[1]
                });
            }
            return result;
        }
        set 
        { 
            var result = value.Select(x => x.StartSlot + "," + x.EndSlot);
            _TimeSlots = string.Join("|", result.ToArray());  
        }
    }
