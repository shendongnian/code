    namespace Global{
    public class Options{
    public static Options _Instance;
    void Awake(){
    if (_Instance == null)
    {
    _Instance = this;
    }
    }
    }    
    }
