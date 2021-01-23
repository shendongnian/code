    public int CompareTo(SerieResultForPilot other){
        var result this.Total - other.Total;
        if (result != 0){
            return result;
        }else{
            var thisResults = this.SerieResultEntries.OrderBy(x => x.SerieResultEntries.Points).toArray();
            var otherResults = his.SerieResultEntries.OrderBy(x => x.SerieResultEntries.Points).toArray();
            for (var i=0; i< thisResults.Count; i++){
                if (thisResults[i] != otherResults[i]){
                    return thisResults[i] - otherResults[i];
                }
            }
            return 0;
        }
    }
