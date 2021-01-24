    if (dtFill.Rows[0]["ADD_FLAG"].ToString() == "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() == "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() == "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() == "Y")
            {
                btnSaveExit.Enabled = true; btnDelete.Enabled = true; btnClear.Enabled = true;
                txtAbbreviation.Enabled = true; txtadd1.Enabled = true; txtadd2.Enabled = true; txtadd3.Enabled = true;
                ddlCountry.Enabled = true; check_desc.Enabled = true; txtdesc.Enabled = true;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() == "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() == "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() == "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() != "Y")
            {
                btnSaveExit.Enabled = true; btnDelete.Enabled = false; btnClear.Enabled = true;
                txtAbbreviation.Enabled = true; txtadd1.Enabled = true; txtadd2.Enabled = true; txtadd3.Enabled = true;
                ddlCountry.Enabled = true; check_desc.Enabled = true; txtdesc.Enabled = true;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() == "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() == "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() != "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() != "Y")
            {
                btnSaveExit.Enabled = true; btnDelete.Enabled = false; btnClear.Enabled = true;
                txtAbbreviation.Enabled = true; txtadd1.Enabled = true; txtadd2.Enabled = true; txtadd3.Enabled = true;
                ddlCountry.Enabled = true; check_desc.Enabled = true; txtdesc.Enabled = true;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() == "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() != "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() != "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() != "Y")
            {
                btnSaveExit.Enabled = true; btnDelete.Enabled = false; btnClear.Enabled = true;
                txtAbbreviation.Enabled = false; txtadd1.Enabled = false; txtadd2.Enabled = false; txtadd3.Enabled = false;
                ddlCountry.Enabled = false; check_desc.Enabled = false; txtdesc.Enabled = false;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() != "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() != "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() != "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() != "Y")
            {
                btnSaveExit.Enabled = false; btnDelete.Enabled = false; btnClear.Enabled = true;
                txtAbbreviation.Enabled = false; txtadd1.Enabled = false; txtadd2.Enabled = false; txtadd3.Enabled = false;
                ddlCountry.Enabled = false; check_desc.Enabled = false; txtdesc.Enabled = false;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() != "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() == "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() == "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() == "Y")
            {
                btnSaveExit.Enabled = false; btnDelete.Enabled = true; btnClear.Enabled = true;
                txtAbbreviation.Enabled = true; txtadd1.Enabled = true; txtadd2.Enabled = true; txtadd3.Enabled = true;
                ddlCountry.Enabled = true; check_desc.Enabled = true; txtdesc.Enabled = true;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() != "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() != "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() == "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() == "Y")
            {
                btnSaveExit.Enabled = false; btnDelete.Enabled = true; btnClear.Enabled = true;
                txtAbbreviation.Enabled = false; txtadd1.Enabled = false; txtadd2.Enabled = false; txtadd3.Enabled = false;
                ddlCountry.Enabled = false; check_desc.Enabled = false; txtdesc.Enabled = false;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() != "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() != "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() != "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() == "Y")
            {
                btnSaveExit.Enabled = false; btnDelete.Enabled = true; btnClear.Enabled = true;
                txtAbbreviation.Enabled = false; txtadd1.Enabled = false; txtadd2.Enabled = false; txtadd3.Enabled = false;
                ddlCountry.Enabled = false; check_desc.Enabled = false; txtdesc.Enabled = false;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() == "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() != "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() == "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() != "Y")
            {
                btnSaveExit.Enabled = true; btnDelete.Enabled = false; btnClear.Enabled = true;
                txtAbbreviation.Enabled = true; txtadd1.Enabled = true; txtadd2.Enabled = true; txtadd3.Enabled = true;
                ddlCountry.Enabled = true; check_desc.Enabled = true; txtdesc.Enabled = true;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() != "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() == "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() != "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() == "Y")
            {
                btnSaveExit.Enabled = false; btnDelete.Enabled = true; btnClear.Enabled = true;
                txtAbbreviation.Enabled = false; txtadd1.Enabled = false; txtadd2.Enabled = false; txtadd3.Enabled = false;
                ddlCountry.Enabled = false; check_desc.Enabled = false; txtdesc.Enabled = false;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() == "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() != "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() == "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() == "Y")
            {
                btnSaveExit.Enabled = true; btnDelete.Enabled = true; btnClear.Enabled = true;
                txtAbbreviation.Enabled = true; txtadd1.Enabled = true; txtadd2.Enabled = true; txtadd3.Enabled = true;
                ddlCountry.Enabled = true; check_desc.Enabled = true; txtdesc.Enabled = true;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() == "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() == "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() != "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() == "Y")
            {
                btnSaveExit.Enabled = true; btnDelete.Enabled = true; btnClear.Enabled = true;
                txtAbbreviation.Enabled = true; txtadd1.Enabled = true; txtadd2.Enabled = true; txtadd3.Enabled = true;
                ddlCountry.Enabled = true; check_desc.Enabled = true; txtdesc.Enabled = true;
            }
            if (dtFill.Rows[0]["ADD_FLAG"].ToString() != "Y" && dtFill.Rows[0]["MODIFY_FLAG"].ToString() != "Y" && dtFill.Rows[0]["VIEW_FLAG"].ToString() == "Y" && dtFill.Rows[0]["DEL_FLAG"].ToString() != "Y")
            {
                btnSaveExit.Enabled = false; btnDelete.Enabled = false; btnClear.Enabled = true;
                txtAbbreviation.Enabled = false; txtadd1.Enabled = false; txtadd2.Enabled = false; txtadd3.Enabled = false;
                ddlCountry.Enabled = false; check_desc.Enabled = false; txtdesc.Enabled = false;
            }
