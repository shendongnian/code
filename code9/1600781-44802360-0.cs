    public class Info
        {
            public string _Info { get; set; }
            public DateTime _Date { get; set; }
        }
        
            List<Info> infos = new List<Info>();
            //Onload - insert infos from *txt file
            List<DateTime> dates = infos.GroupBy(x => x._Date).Select(y => y.First()).Select(z=>z._Date).ToList();
            //no duplicates dates
            List<string> dateInfos = infos.Where(x => x._Date == selectedDate).Select(z=>z._Info).ToList();
            //show infos for selected date
