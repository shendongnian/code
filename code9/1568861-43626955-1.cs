    MyDataContext myData = new MyDataContext();
    EVRBA evrbas = new EVRBA();
    evrbas.EVRAKTARIH =DateTime.Now;
    try
    {
          myData.EVRBAs.InsertOnSubmit(evrbas);
          myData.SubmitChanges();
    }
    catch (Exception)
    {
          throw;
    }
