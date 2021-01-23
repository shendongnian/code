    [HttpGet]
    public ActionResult GetMemberById(string id) {
        SqlParameter[] SqlParam = { new SqlParameter("@Filter", id) };
        DataTable dTable = MasterMindDB.dTableSP(DbConn, "SP_Get_MemberList", SqlParam);
        List<Member> member = new List<Member>();
    
        foreach (DataRow row in dTable.Rows) {
            member.Add(new Member {
                MemberName = row["Member ID"].ToString(),
                Email = row["Email"].ToString(),
                JoinDate = row["Join Date"].ToString(),
                Status = row["Status"].ToString()
            });
        }
        //Just return JsonResult.
        return Json(member, JsonRequestBehavior.AllowGet);
    }
