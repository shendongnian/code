    public class Serilizer
    {
    public List<Zone> TeamsInZone(string j)
    {
    var a = JsonConvert.DeserializeObject<List<Zone>>(j);
    var list = a.Select(s =>s).Where(t => t.players != null && t.players.Any(u=>u.type == "Keeper")).ToList();
    return list;
    }
    }
