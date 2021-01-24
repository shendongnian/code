    public ActionResult Loops()
    {
        PageViewModel result = new PageViewModel();
        IDataReader dr = null; // some SQL Search
        result.Files = new List<Mp3File>();
        while (dr.Read())
        {
            result.Files.Add(new Mp3File()
            {
               Id = int.Parse(dr["Id"].ToString()),
               Name = dr["Name"].ToString(),
               ContentType = dr["ContentType"].ToString(), //must be something like audio/mp3 for example
               Category = dr["Category"].ToString(),
               Data = (Byte[])dr["Data"]
            });
        }
        return Json(result, JsonRequestBehavior.AllowGet);
    }
