    using System.Linq;
    public string[] getallTourID()
    {
        return TourCollections.Select(o => o.getId).ToArray();
    }
