    // Define new Class
    public class VhcleInfo 
    {
         [DisplayName("Registration Number")
         public string RegNo { get; set; }
         [DisplayName("Make and Model")
         public string MakeModel {get; set; }
         [DisplayName("Year of Manufacture")
         public int Year { get; set; }
    }
    // Create IEnum for Defined Class
    var vlist = from lst in dc.tblVhcleInfos
             select new VhcleInfo() { RegNo = lst.RegNo, MakeModel = lst.makeModel, Year = lst.YOM };
    // Set Data Source
    dataGridView1.DataSource = vlist;
