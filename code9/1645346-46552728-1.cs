    public static void orientation(EntityStateRepository esr, TypeOfE e)
    {
        double heading;
        double pitch;
        double roll;
        Tools.orientation(ent.esr, out heading, out pitch, out roll);
        e.heading = heading;
        e.pitch = pitch;
        e.roll = roll;
    }
    //...
    
    public static void orientation(EntityStateRepository esr, out double  heading, out double pitch, out double roll)
    {
        TaitBryan topoEuler = topoToGeoc.eulerTrans(esr.worldOrienation);
        heading = MathHelper.RadiansToDegrees(topoEuler.psi);
        pitch = MathHelper.RadiansToDegrees(topoEuler.theta);
        roll = MathHelper.RadiansToDegrees(topoEuler.phi);
    }
