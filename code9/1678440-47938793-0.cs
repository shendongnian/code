    public void Process(Data data)
    {
      try
      {
        Thing a = null;
        a.MakeSomething();
      }
      catch( NullPointerException e )
      {   
        CustomCode();
        DoSomething();
      }
      catch(Exception ex)
      {
       CustomCode();
     }
}
