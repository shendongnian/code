    public class MyViewModelSO
    {
        public int selectedValue { get; set; }
        public List<SelectListItem> tickers = HomeController.getTickerName();
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index2007(MyViewModelSO myViewModel) 
        {
            //save
            var value = myViewModel.tickers.Where(r => r.Value == myViewModel.selectedValue.ToString()).
                Select(s => s.Text).ToList();
            
            //put breakpoint here to see value contains text
            //...rest of save
            
            return View(myViewModel);
        }
        public ActionResult Index2007()
        {
            var myViewModel = new MyViewModelSO();
            return View(myViewModel);
        }
        public static List<SelectListItem> getTickerName()
        {
            List<SelectListItem> lstTicker = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(@"Server=.\sqlexpress;DataBase={MyDB};Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ConfAdminCompanies", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        lstTicker.Add(new SelectListItem
                        {
                            Text = rdr["DisplayCompanyName"].ToString(),
                            Value = rdr["code"].ToString()
                        });
                    }
                }
            }
            return lstTicker;
        }
