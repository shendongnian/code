    public static void Main(string[] args)
    {
        ServiceClass entity = new ServiceClass();
        entity.From_Ser_ID = ServiceClass.ServiceID.BTWithdrawal;
        entity.To_Ser_ID = ServiceClass.ServiceID.Ten_KDeposit;
        execute(entity);
    }
