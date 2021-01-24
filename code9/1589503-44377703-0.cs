    class Level
    {
        readonly string levelName;
        Level( String levelName )
        {
            this.levelName = levelName;
        }
        void Setup()
        {
            levelDisplay.Text = levelName;
            SetupTimer();
        }
        virtual void SetupTimer()
        {
             //Default implementation
        }
    }
    class Level1: Level
    {
        Level1() : Level( "LEVEL 1" ) 
        {
        }
        override void SetupTimer()
        {
            //Level1 implementation
        }
    }
