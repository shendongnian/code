    using System.Linq;
    public string[] getallTourID()
    {
        // assumes getId is already a string
        return TourCollections.Select(o => o.getId).ToArray();
    }
