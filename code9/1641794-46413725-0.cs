    protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection path = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            path.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Players", path);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // fill the players list from the database
            List<Players> playerList = new List<Players>();
            playerList = (from DataRow dr in dt.Rows
                          select new Players()
                          {
                              Name = (dr["Name"].ToString()),
                              Order = int.Parse(dr["Order"].ToString()),
                              ID = int.Parse(dr["ID"].ToString())
                          }).ToList();
            playerList = playerList.OrderBy(x => x.ID).ToList();
            // consume the players list in increasing increments
            List<Tier> tierList = new List<Tier>();
            for(var tierLength = 1; playerList.Count > 0; tierLength++)
            {
                var tier = new Tier();
                tier.Players = new List<Players>();
                tier.TierLength = tierLength;
                for(var playerCount = 0; playerCount < tierLength && playerList.Count > 0; playerCount++)
                {
                    tier.Players.Add(playerList[0]);
                    playerList.RemoveAt(0);
                }
                tierList.Add(tier);
            }
            // bind the tierList to the outer datalist element
            // the inner datalist element will be a child
            DataList0.DataSource = tierList;
            DataList0.DataBind();
        }
    }
    public class Players
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public int ID { get; set; }
    }
    public class Tier
    {
        public List<Players> Players { get; set; }
        public int TierLength { get; set; }
    }
