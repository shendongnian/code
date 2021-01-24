    public List<double> GetDescriptiveStat()
    {
        List<double> data = new List<double>();
        for (int i = 0; i < 94; i++)
        {
            data.Add(dblValues[i][0]);
        }
        return data;
    }
