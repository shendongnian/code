    public JsonResult getSecondDDL(){
       List<String[]> obj = new List<String[]>();
       string param1= Request.Form["param1"];
       DataTable dt = .. (sql result)
       foreach (DataRow dr in dt.Rows)
       {
          string[] tmp = new string[2];
          tmp[0] = dr["building_unit"].ToString();
          tmp[1] = dr["building_unit"].ToString();
          obj.add(tmp)
       }
      return JsonResult(obj);
    }
