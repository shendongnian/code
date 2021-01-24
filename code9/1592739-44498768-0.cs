    public class Mainclass
    {
       public guid faceId;
       IEnumerable<faceRectangle>
       IEnumerable<faceAttributes>
    }
    public class faceRectangle
    {
    
    }
    
    public class faceAttributes
    {
    
    }
    
    
    Mainclass backdata =  JsonConvert.DeserializeObject<Mainclass>(Jsondata , new DataConverter())
