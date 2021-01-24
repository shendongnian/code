    public bool CompareAllLegLocations()
        {
            if (_legNumberToLegIndex.Count > 0)
            {
                if (_legNumberToLegIndex.Count == 1)
                    return false;
                
                var legs = _legNumberToLegIndex.Values;
                var firstLeg = _legNumberToLegIndex.FirstOrDefault().Value; // Taking first leg to determine the distinct list of locations.
                var firstLegLocations = firstLeg.Exhibitions.Select(ex => ex.Location).Distinct().OrderBy(x => x); // Determining distinct and ordered list of locations.
                foreach (var leg in legs)
                {
                    var locations = leg.Exhibitions.Select(ex => ex.Location).Distinct().OrderBy(x => x); //Determining distinct and order list of locations for each of the leg.
                    if (!locations.SequenceEqual(firstLegLocations)) //Comparing the list of locations of current leg to that of the first leg.
                        return true;
                }
                return false;
            }
            return false;
        }
