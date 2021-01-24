    public class Stereo1 : SteroController
    {
        public override string SteroeName
        {
            get
            {
                return "Streo1";
            }
        }
    
        public override string VolumeCommand
        {
            get
            {
                return "Command1";
            }
        }
    
        public override void IncreaseVolume()
        {
            //Do anything with VolumCommand
        }
        public Stereo1()
        {
    
        }
    }
    public class Stereo2 : SteroController
    {
        public override string SteroeName
        {
            get
            {
                return "Streo2";
            }
        }
    
        public override string VolumeCommand
        {
            get
            {
                return "Command2";
            }
        }
    
        public override void IncreaseVolume()
        {
            //Do anything with VolumCommand2
        }
        public Stereo2()
        {
    
        }
    }
