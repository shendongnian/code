    public static double NormalizeAngle(double theAngle)
    {
        if(theAngle <= -180)
        {
            //we keep adding 360° until we reach an acceptable value.
            while(!IsValidAngle(theAngle))
            {
                theAngle += 360;
            }
            
            return theAngle;
        }
        
        if(180 <= theAngle)
        {
            //we keep subtracting 360° until we reach an acceptable value.
            while(!IsValidAngle(theAngle))
            {
                theAngle -= 360;
            }
            
            return theAngle;
        }
        
        //if neither if block was entered, then the angle was already valid!
        return theAngle;
    }
    private static bool IsValidAngle(double theAngle)
    {
        return (-180 <= theAngle) && (theAngle <= 180);
    }
