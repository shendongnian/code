    MyDataContext myData = new MyDataContext();
    EVRBA evrbas = new EVRBA();
    evrbas.EVRAKTARIH =DateTime.Today;
    try
    {
          myData.EVRBAs.InsertOnSubmit(evrbas);
          myData.SubmitChanges();
    }
    catch (Exception)
    {
          throw;
    }
