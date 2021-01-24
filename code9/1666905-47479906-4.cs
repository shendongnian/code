    // GET: Announce/Add new announce
    public ActionResult AddOffer()
    {
        string sql = "select typeId, typeDesc from announceTypes where parentTypeId = 1";
        using (SqlConnection cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            var apartmentTypeList = new List<AnnounceTypeList>();
            foreach (DataRow dr in dt.Rows)
            {
                var apartmentType = new AnnounceTypeList
                {
                    SubTypeId = Convert.ToInt32(dr["TypeId"]),
                    TypeDesc = dr["TypeDesc"].ToString()
                };
                apartmentTypeList.Add(apartmentType);
            }
             AddOfferViewModel viewModel = new AddOfferViewModel();
             viewModel.AnnouncementTypeSelectList  = new SelectList(apartmentTypeList,"SubTypeId","TypeDesc")
            return View(viewModel);
        }
    }
