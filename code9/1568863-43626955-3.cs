    MyDataContext myData = new MyDataContext();
    EVRBA evrbas = new EVRBA();
    evrbas.EVRAKTARIH =DateTime.Parse(DateTime.Now.ToString("o"));
    try
    {
          myData.EVRBAs.InsertOnSubmit(evrbas);
          myData.SubmitChanges();
    }
    catch (Exception)
    {
          throw;
    }
