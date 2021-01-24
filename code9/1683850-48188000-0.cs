    using System.Linq;
    ...
    private void showNearbyPlaces(List<JavaDictionary<string, string>> placeList)
    {
        for (int eachPlace = 0; eachPlace < placeList.Count; eachPlace++)
        {
            JavaDictionary<string, string> googlePlace = placeList.ElementAt(eachPlace);
        }
    }
