    namespace WebApplication8
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            List<food> foodlist = new List<food>();
            protected void Page_Load(object sender, EventArgs e)
            {
                food fod = new food();
                fod.foodId = 1;
                fod.foodName = "testA";
                fod.foodtypes = "Chinese";
    
                foodlist.Add(fod);
    
                food fod1 = new food();
                fod1.foodId = 2;
                fod1.foodName = "testb";
                fod1.foodtypes = "Chinese";
                foodlist.Add(fod1);
    
                food fod3 = new food();
                fod3.foodId = 3;
                fod3.foodName = "testc";
                fod3.foodtypes = "Malay";
                foodlist.Add(fod3);
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                string selectedDropdownlist = DropDownList1.Text;
    
                GridView1.DataSource = foodlist.Where(x => x.foodtypes == selectedDropdownlist).ToList();
    
                GridView1.DataBind();
            }
        }
    }
