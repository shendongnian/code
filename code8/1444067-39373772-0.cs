    JamesBondObject oResult = (JamesBondObject) JsonConvert.DeserializeObject(sResponse, typeof( JamesBondObject ) );
    class JamesBondObject {
        int id;
        string name;
        Mission[] missions;
    }
    
    class Mission {
        int year;
        string title;
    }
