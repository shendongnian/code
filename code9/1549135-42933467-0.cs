            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Web;
            using System.Web.UI;
            using System.Web.UI.WebControls;
           namespace SampleTest1
           {
                public partial class _Default : Page
                {
                     protected void Page_Load(object sender, EventArgs e)
                     {
                         List<string> licenseTypeArray = new List<string>() { "Type 1", "Type 2", "Type 3" };
                         List<string> totalLicenseArray = new List<string>() { "100", "200", "300" };
                         List<string> consumedLicenseArray = new List<string>() { "50", "100", "150" };
                         //A generic list of the new entity class that wraps the three properties (columns)
                         List<LicenseInfo> licensesList = new List<LicenseInfo>();
                     //concat zip the three lists with a comma-separated for each entry    in the new list with this pattern ("License Type, Total Count, Consumed Count"). 
                     //Example("Entrprise License,200,50")
                     List<string> licensesConcatenatedList = licenseTypeArray.Zip(totalLicenseArray.Zip(consumedLicenseArray,
                (x, y) => x + "," + y),
                (x1, y1) => x1 + "," + y1).ToList();
                     licensesConcatenatedList.ForEach(t => licensesList.Add(new LicenseInfo
                     {
                         LicenseType = t.Split(new char[] { ',' })[0],
                         TotalLicenesesCount = int.Parse(t.Split(new char[] { ',' })[1]),
                         ConsumedLicensesCount = int.Parse(t.Split(new char[] { ',' })[2])
                     }));
                    GridView1.DataSource = licensesList;
                    GridView1.DataBind();
           }
         }
            class LicenseInfo
            {
                public string LicenseType { get; set; }
                public int TotalLicenesesCount { get; set; }
                public int ConsumedLicensesCount { get; set; }
            }
         }
