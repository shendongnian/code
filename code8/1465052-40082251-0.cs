          [HttpPost]
        public ActionResult bindCityList(int stateid)
        {
            List<SelectListItem> lstcity = new List<SelectListItem>();
            try
            {
                Panel cs = new Panel();
                DataTable dt = new DataTable();
                dt = cs.getCityVsState(Conn, stateid);
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    lstcity.Add(new SelectListItem { Text = @dr["CityName"].ToString(), Value = @dr["CityID"].ToString() });
                }
            }
            catch (Exception ex)
            {
                logger.WriteErrorToFile("Panel::bind City List :" + ex.Message.ToString());
            }
            finally
            {
                Conn.Close();
            }
            return Json(lstcity.AsEnumerable());
        }
