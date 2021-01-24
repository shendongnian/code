    static volatile GameManager _instance;
    public static GameManager instance(){
        if (_instance== null) {              //0
            synchronized(GameManager.class) {  //1
                if (_instance == null)          //2
                    _instance= new GameManager ();  //3
            }
        }
        return o;
    }
