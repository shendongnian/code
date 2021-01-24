    public class PageContent {
        public int PageID { get; set; }
        public string PageText {get; set; }
        public PageContent() {}
        public PageContent (int ContentID) {
            PageID = ContentID;
            using (SqlConnection conn = new SqlConnection(YourConnString)) {
                using (SqlCommand cmd = new SqlCommand("SELECT PageText FROM PageContent WHERE (PageID = @PageID)", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Paramaters.AddWithValue("@PageID", PageID);
                    try {
                        conn.Open();
                        PageText = (string)cmd.ExecuteScalar();
                    }
                    catch (Exception ex) {
                        PageText = "An Error has occurred";
                        // your error handling here
                    }
                    finally { conn.Close(); }
                }
            }
        }
    }
