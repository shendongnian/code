    public class Broker
    {
      OleDbConnection konekcija;
      OleDbCommand komanda;
      void konektujSe()
      {
            konekcija = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\...;Persist Security Info=False;");
            komanda = konekcija.CreateCommand();
      }
      private static Broker broker;
      public static Broker dajBrokera()
      {
          if (broker == null)
          {
              broker = new Broker();
          }
          return broker;
      }
      private Broker()
      {
          konektujSe();
      }
    }
