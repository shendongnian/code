    private string getTimes(int user)
    {
        string jSON = "";
        string x = "&quot;";
        switch(user)
        {
            case 1:
                jSON = "{'startTime':08:00,'endTime':'16:00'}".Replace("'",x);
                break;
            case 2:
                jSON = "{'startTime':09:00,'endTime':'17:00'}".Replace("'", x);
                break;
            case 3:
                jSON = "{'startTime':12:00,'endTime':'20:00'}".Replace("'", x); ;
            break;
        }
        //jSON = JsonConvert.SerializeObject(jSON);
        return jSON; //<-- already serialised
    }
