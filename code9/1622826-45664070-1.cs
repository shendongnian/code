    public interface IId
    {
        int ID { get; set; }
    }
    
    public class Exit : IId
    {
        int ID { get; set; }
    }
    
    public class Room : IId
    {
        int ID { get; set; }
    }
    
    private int _GetIDFromList<T>(List<T> list, int indexOfList) where T : IId
    {
        return list[indexOfList].ID;    // this gives me error it can't find ID
    }
