    var query = (from con in db.Containers
                 join v in db.Vehicles on con.cont_vehicleid equals v.vehl_VehicleID
                 join cust in db.Custom_Captions on v.vehl_state equals cust.Capt_Code
                 where cust.Capt_Family == "vehl_state" && v.vehl_Deleted == null && con.cont_Deleted == null &&
                 v.vehl_ClearanceCompany == p.pusr_CompanyId
              
                 select new
                 {
                   cont_name = con.cont_Name,
                   vehl_Name = v.vehl_Name,
                   VehicleState = v.vehl_state,
                   vehl_drivername = v.vehl_drivername,
                   vehl_entrancedate = v.vehl_entrancedate,
                   vehl_customsdec = v.vehl_customsdec,
                   cont_rampid = v.vehl_rampid
                 }).ToList();
    if(txtConNo.Text != "")
    {
      query = query.Where(con => con.cont_Name.Contains(txtContNo.Text))
    }
    if(txtCust.Text != "")
    {
      query = query.Where(con => con.cont_customdec.Contains(txtCust.Text))
    }
