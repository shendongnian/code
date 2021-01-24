     void Start () {
        /////////////////////// save to json
        JSONObject jsonSave = new JSONObject();
        for(int i=0; i < packsInfo.Length; i++) {
            JSONObject packJson = new JSONObject();
            packJson.AddField("number", packsInfo[i].number);
            packJson.AddField("angle", packsInfo[i].angle);
            packJson.AddField("z_position", packsInfo[i].zPosition);
            packJson.AddField("beat_case_distance", packsInfo[i].beatCaseDistance);
            packJson.AddField("gun_distance", packsInfo[i].gunDistance);
            jsonSave.Add(packJson);
        }
        System.IO.StreamWriter streamWritter = new System.IO.StreamWriter(@"C:\MyGameFiles\packs.json");
        streamWritter.WriteLine(jsonSave.Print(true));
        streamWritter.Close();
        streamWritter = null;
        /////////////////////// read json
        System.IO.StreamReader reader = new System.IO.StreamReader(@"C:\MyGameFiles\packs.json");
        string jsonString = reader.ReadToEnd();
        reader.Close();
        reader = null;
        JSONObject jsonRead = new JSONObject(jsonString);
        packsInfo = new Pack[jsonRead.Count];
        for(int i =0; i < jsonRead.Count; i ++) {
            Pack pack = new Pack();
            pack.number = (int)jsonRead[i]["number"].i;
            pack.angle = (int)jsonRead[i]["angle"].i;
            pack.zPosition = jsonRead[i]["z_position"].f;
            pack.beatCaseDistance =jsonRead[i]["beat_case_distance"].f;
            pack.gunDistance = jsonRead[i]["gun_distance"].f;
            packsInfo[i] = pack;
        }
    }
