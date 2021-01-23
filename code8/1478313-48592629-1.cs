    public class Afktimer
    {
        public void StartProgram()
        {
            while (true)
            {
               SnapsEngine.SetTitleString("Afk Timer");
               SnapsEngine.Delay(3.0);
               SnapsEngine.SpeakString("Twenty minutes remaining");
               SnapsEngine.Delay(600.0);
               SnapsEngine.SpeakString("Ten minutes remaining");
               SnapsEngine.Delay(300.0);
               SnapsEngine.SpeakString("Five minutes remaining");
               SnapsEngine.Delay(240.0);
               SnapsEngine.SpeakString("One minute remaining");
               SnapsEngine.Delay(60.0);
               SnapsEngine.SpeakString("Timer resetting");
            }
        }
    } 
