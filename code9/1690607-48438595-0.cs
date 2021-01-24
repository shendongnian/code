    public static class DesignTimeHelper
    {
        public static bool DesignModeOn { get; private set; } = true;
    }
 
    public static void TurnOffDesignMode()
    {
        DesignModeOn = false;
    }
    }
