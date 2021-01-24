    dtConfReg = new DataTable();
    dtConfReg.ReadXml(Principale.strPathConfig + "\\ConfigRegulators.xml");
    dtConfReg.TableName = "ConfigReg";
    dtConfReg.DefaultView.RowFilter = "Address = '92'";
    bsouReg = new BindingSource();
    bsouReg.DataSource = dtConfReg;
    dgvwConfigReg.DataSource = bsouReg;
