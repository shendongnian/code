    private static void Main(string[] args)
    {
        var genes = GetGenes(9, 2);
    }
    
    private static List<bool[]> GetGenes(int workinghours, int estimateddutyduration)
    {
        // get the base representation 
        var hours = GetHours(workinghours, estimateddutyduration);
        var list = new List<bool[]>();
        for (int i = 0; i < (workinghours-estimateddutyduration)+1; i++)
        {
            // add
            list.Add(hours);
            // switch
            hours = SwitchArray(hours);
        }
        return list;
    }
    
    private static bool[] SwitchArray(bool[] array)
    {
        // copy the array to a list
        var temp = array.ToList();
        // insert the last element at the front
        temp.Insert(0, temp.Last());
        // remove the last
        temp.RemoveAt(temp.Count-1);
        // return as array
        return temp.ToArray();
    }
    
    private static bool[] GetHours(int totalhours, int taskduration)
    {
        // initialise the list
        var hours = new List<bool>(totalhours);
        // fill the list for the number of working hours
        for (int i = 0; i < totalhours; i++)
        {
            hours.Add(false);
        }
        // iterate for the task duration and set the hours as working
        for (int i = 0; i < taskduration; i++)
        {
            hours[i] = true;
        }
        // return as array
        return hours.ToArray();
    }
