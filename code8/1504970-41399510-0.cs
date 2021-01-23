    public class CustomList
    {
        public string FullName { get; set; }
        public int AgreementID{ get; set; }
    }
    var Custom = from i in listofClients
                 from j in listofAgreements
                 Where i.ClientID == j.ClientID
                 select  new CustomList{
                      FullName = i.FullName ,
                      AgreementID = j.AgreementID
                 }.ToList();
