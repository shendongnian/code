    public static void execute(ServiceClass sc)
    {
        sc.GetType().GetMethod(sc.From_Ser_ID.ToString()).Invoke(sc, null);
        sc.GetType().GetMethod(sc.To_Ser_ID.ToString()).Invoke(sc, null);
    }
