    public class MusicControl : MonoBehaviour {
    
    
        [FMODUnity.EventRef]
        public string explosion = "event:/EXPLOSION";
        [FMODUnity.EventRef]
        public string shoot = "event:/SHOOT SOUND";
        [FMODUnity.EventRef]
        public string menuMusic = "event:/MENU MUSIC";
    
        int val;
    
        public FMOD.Studio.EventInstance musicEv;
        public FMOD.Studio.ParameterInstance musicPar;
    
        private Player player;
    
        void Awake()
        {
            //Initialize musicEv
            musicEv = FMODUnity.RuntimeManager.CreateInstance(menuMusic);
            //Initialize musicPar(done with the out keyword)
            musicEv.getParameter("HEALTH", out musicPar);
    
            //Initialize player
            player = GameObject.Find("Player").GetComponent<Player>();
        }
    
        //music for menu, I'm call this function when my stage starts(menu game)
        public void MenuMusic()
        {
            musicEv.start();
        }
    
        //music for level 1, I'm call this function when my stage starts(level game)
        public void LevelMusic() 
        {
            musicEv.setParameterValue("FIGHT MUSIC", 100f);
            musicEv.getParameter("HEALTH", out musicPar);
            musicPar.setValue(100); 
    
            musicEv.start();
        }
    
        //I'm call this function when stages is close up
        public void StopMusic()
        {
            musicEv.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    
        // I'm take current Health from Player script
        void Update()
        {
            val = player.stats.curHealth;
            musicPar.setValue(val);
        }
    }
