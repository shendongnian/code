        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        [System.Web.Script.Services.ScriptService]
        public class WebServiceFile : System.Web.Services.WebService
        {
    
            [WebMethod]
            //[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
            public  string GetProductStock(string productId, string TerminalId, string CCPId)
            {
                ProductsDomain objProduct = new ProductsDomain();
                objProduct.Product_Id = Convert.ToInt32(productId);
                objProduct.TerminalId = Convert.ToInt32(TerminalId);
                objProduct.CCPId = Convert.ToInt32(CCPId);
                DataTable dt = objProduct.GetProductDetail();
                if (dt.Rows.Count > 0)
                {
                    return JsonConvert.SerializeObject(dt.Rows[0]["CurrentQty"].ToString());
                }
                else
                {
                    return JsonConvert.SerializeObject("0");
                }
            }
    
            public class ProductsDomain
            {
                public int Product_Id { get; set; }
                public int TerminalId { get; set; }
                public int CCPId { get; set; }
                public DataTable GetProductDetail()
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CurrentQty");
                    DataRow dr = dt.NewRow();
                    dr["CurrentQty"] = "Smith";
                    dt.Rows.Add(dr);
                    DataRow dr1 = dt.NewRow();
                    dr1["CurrentQty"] = "John";
                    dt.Rows.Add(dr1);
                    return dt;
    
                }
            }
    
        }
