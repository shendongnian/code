    [WebMethod]        
        public List<ChartDatasets> getnpsTrend(string region, string client, string product)
        {
            List<ChartDatasets> chart1 = new List<ChartDatasets>();
            List<string> lblnames = new List<string>();
            DataTable dt = biz.FetchData_RCP("", region, client, product);
            dt.TableName = "data";
            foreach (DataRow drow in dt.Rows)
            {
                lblnames.Add(drow["Timeline"].ToString());                
            }
            Labels lbl1 = new Labels();
            lbl1.LabelNames = lblnames;
            
            List<Decimal> lst_dataItem_1 = new List<Decimal>();
            foreach (DataRow dr in dt.Rows)
            {
                lst_dataItem_1.Add(Convert.ToDecimal(dr["NPSScore"].ToString()));
            }
            dataset_deci ds1_class = new dataset_deci();
            ds1_class.Value = lst_dataItem_1;
           
            List<Decimal> lst_dataItem_2 = new List<Decimal>();
            foreach (DataRow dr in dt.Rows)
            {
                lst_dataItem_2.Add(Convert.ToDecimal(dr["Promoter_Count"].ToString()));
            }
            dataset_deci ds2_class = new dataset_deci();
            ds2_class.Value = lst_dataItem_2;
            chart1.Add(new ChartDatasets { Lbls = new List<Labels> { lbl1 }, ds1 = new List<dataset_deci> { ds1_class }, ds2 = new List<dataset_deci> { ds2_class } });
            return chart1;
        }
        public class ChartDatasets
        {
            public List<Labels> Lbls;
            public List<dataset_deci> ds1;
            public List<dataset_deci> ds2;
        }
        public class Labels
        {
            public List<string> LabelNames;
        }
        public class dataset_deci
        {
           public List<Decimal> Value;
        }
      
