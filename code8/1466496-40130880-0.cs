      var query = (from con in db.Containers
                         join v in db.Vehicles on con.cont_vehicleid equals v.vehl_VehicleID
                         join cust in db.Custom_Captions on v.vehl_state equals cust.Capt_Code
                         where cust.Capt_Family == "vehl_state" && v.vehl_Deleted == null && con.cont_Deleted == null &&
                         v.vehl_ClearanceCompany == p.pusr_CompanyId && con.cont_Name.Contains(txtContNo.Text == null ? con.cont_Name : txtContNo.Text)
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
     var query2 = (from con in db.Containers
                          join v in db.Vehicles on con.cont_vehicleid equals v.vehl_VehicleID
                          join cust in db.Custom_Captions on v.vehl_state equals cust.Capt_Code
                          where cust.Capt_Family == "vehl_state" && v.vehl_Deleted == null && con.cont_Deleted == null &&
                          v.vehl_ClearanceCompany == p.pusr_CompanyId && con.cont_customdec.Contains(txtCust.Text == null ? con.cont_customdec : txtCust.Text)
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
   
        if (txtContNo.Text != "")
        {
            rptVehl.DataSource = query;
            rptVehl.DataBind();
        }
        if (txtCust.Text != "")
        {
            rptVehl.DataSource = query2;
            rptVehl.DataBind();
        }
