    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using System;
    
    //PROGRAMME
    static void Main1()
    {
      List<string> listeJournaux = new List<string>();
      string[,] listePronosticNumero = new string[66, 34];
      List<string> listeDate = new List<string>();
      // ENVOIE BDD
      //Bdd bdd = new Bdd();
      using (var conn = new SqlConnection("SERVER=127.0.0.1; DATABASE=test2; UID=root; PASSWORD="))
      {
        conn.Open();
        using (var adapter = new SqlDataAdapter("Select pro_id, pro_numeros, pro_date, pro_journal from pronostique where 1 = 0", conn))
        {
          using (var pronostique = new DataTable("pronostique"))
          {
            adapter.Fill(pronostique);
            using (var builder = new SqlCommandBuilder(adapter))
            {
              builder.GetInsertCommand();
              //builder.GetUpdateCommand();// uncomment as needed
              //builder.GetDeleteCommand();// uncomment as needed
              for (int y = 0; y <= 56 - 1; y++)
              {
                for (int i = 0; i <= 2; i++)
                {
                  var pronostique1 = new Pronostique() { journal = listeJournaux[y], numeros = listePronosticNumero[y, i], date = listeDate[i] };
                  var newRow = pronostique.NewRow();
                  newRow["pro_id"] = DBNull.Value;
                  newRow["pro_numeros"] = pronostique1.numeros;
                  newRow["pro_date"] = pronostique1.date;
                  newRow["pro_journal"] = pronostique1.journal;
                  pronostique.Rows.Add(newRow);
                }
              }
              adapter.Update(pronostique);
            }
          }
        }
      }
    }
