    public List<Coordinates> SelectCoords(List<Coordinates> originalList, float? X, float? Y,float? Z)
        {
            List<Coordinates> filteredList = new List<Coordinates>(originalList);
            if (X != null)
            {
                filteredList = filteredList.Where(v => v.XCoord == X).ToList();
            }
            if (Y != null)
            {
                filteredList = filteredList.Where(v => v.YCoord == Y).ToList();
            }
            if (X != null)
            {
                filteredList = filteredList.Where(v => v.ZCoord == Z).ToList();
            }
            return filteredList;
        }
