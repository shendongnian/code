     public class Rootobject
     {
         //Employer and Carrier information 
         public string Employer { get; set; }
         public string Phone { get; set; }
         public string InsUnder { get; set; }
         public string Carrier { get; set; }
         public string CarrierPh { get; set; }
         public string Group { get; set; }
         public string MailTo { get; set; }
         public string MailTo2 { get; set; } //place holder
         public string MailTo3 { get; set; }
         public string EClaims { get; set; }
         public string FAXClaims { get; set; }
         public string DMOOption { get; set; }
     }
     public class iapVm
     {
         public List<Rootobject> data { get; set; }
     }
    
     public class Class1
     {
         public iapVm TestDeserializingValidResponseContent()
         {
             //Response object
             iapVm list = new iapVm();
             string content = "[{\"_id\":\"asdf\",\"Employer\":\"1 800 Foo & Bar (Schedule Plan)\",\"EmpNumberXXX\":\"(333)-111-2222 : (800)-234-2344\",\"InsUnder\":\"asdf asdf\",\"DMOOption\":\"No\",\"Medical\":\"asdf (800)-234-2344 Group#:23443\",\"DateXXX\":\"May\",\"Carrier\":\"Cigna\",\"‌​CarrierPh\":\"(222)-‌​234-234234\",\"FAXClai‌​ms\":\"No. Will Not Accept\",\"Plan\":\"Self-Funded\",\"Group\":\"Cigna (800)-234-2344 Group#:23443\",\"GroupNum\":\"2343\",\"EClaims\":\"Yes\"}]";
             List<Rootobject> lstRootobject = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rootobject>>(content);
             list.data = lstRootobject;
             return list;
         }
     }
