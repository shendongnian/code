    public class ViewModel
    {
        public ViewModel()
        {
            fill();
        }
        private void fill()
        {
            sqlQuery = string.Empty;
            using (sqlcon = new SqlConnection(sqlConString))
            {
                sqlQuery = "Select ID, Angebotsnummer, Kundenname, Bauvorhaben, KundenstatusID as 'Kundenstatus', AquisekanalID as 'Aquisekanal', Ansprechpartner, AusführungszeitraumID as 'Ausführungszeitraum/Quartal', Auftragssumme, Zuschlagswahrscheinlichkeit as '%', KalkSumme, AngebotsstatusID as 'Angebotsstatus', Absagegrund From Angebote;";
                sqlcmd = new SqlCommand(sqlQuery, sqlcon);
                sqlda = new SqlDataAdapter(sqlcmd);
                dt = new DataTable("Angebote");
                sqlda.Fill(dt);
                DataView = dt.DefaultView;
                string sum;
                Sum = getSum();
                sqlcon.Close();
            }
        }
        public DataView DataView { get; private set; }
        public string Sum { get; private set; }
    }
