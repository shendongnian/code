     try {
    
         var xmlStr = File.ReadAllText(Server.MapPath("~/SkillSet.xml"));
         var str = XElement.Parse(xmlStr);
         var result = str.Elements("SkillSets").
         Where(x => x.Element("Employee_ID").Value.Equals(txtEmpid.Text)).ToList();
    
         grdxml.DataSource = result.ToList();
         grdxml.DataBind();
     }  
     catch(Exception ex)
     {
        lblerror.Text = ex.ToString();
     }
