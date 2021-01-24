    public string ConceptValue(int concept)
    {
        switch (conceptOrder)
        {
            case 1:
                return Warehouse;
            case 2:
                return Commodity;
            // etc...
            default:
                throw new ArgumentException("Unhandled Concept", "concept");
        }
    }
