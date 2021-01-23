    Dictionary<string, List<DataRow>> mylist = new Dictionary<string, List<DataRow>>();
    string ThisConcat = "";
    for (int i = 0; i < dtLogData.Rows.Count - 1; i++) {
        foreach (int ColNum in ColNumList) {
            ThisConcat += dtLogData.Rows[i].Field<string>(ColNum - 1);
        }
        if (! mylist.ContainsKey(ThisConcat)) 
            mylist[ThisConcat] = new List<DataRow>();
        mylist[ThisConcat].Add(dtLogData.Rows[i]);
        ThisConcat = "";
    }
    foreach (var p in mylist) {
        if (p.Value.Count > 1) {
            foreach (var r in p.Value) {
                r[ColCnt] = MyErrorString;
            }
        }
    }
