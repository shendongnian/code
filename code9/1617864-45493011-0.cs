    private List<Participant> CollapseResultSet(List<Participant> rawdataset)
    {
        List<Participant> ret = new List<Participant>();
        if (!rawdataset.Any())
        {
            return ret;
        }
        else
        {
            List<string> partIds = rawdataset.Select(p => p.ID).Distinct().ToList();
            foreach (string pId in partIds)
            {
                Participant tmp = rawdataset.Where(p => p.ID == pId).FirstOrDefault();
                tmp.PhoneNumbers = rawdataset.Where(p => p.ID == pId).Select(n => n.PhoneNumbers[0]).ToList();
                ret.Add(tmp);
            }
            return ret;
        }
    }
