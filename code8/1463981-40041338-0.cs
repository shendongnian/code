            DataTable dtFiltered = new DataTable();
            var dtFilteredTemp = FixedQuestions.AsEnumerable().Where(X => X.Field<string>("columnName") == "myValue");
            if (dtFilteredTemp.AsDataView().Count > 0)
            {
                dtFiltered = dtFilteredTemp.CopyToDataTable();
            }
            rp.DataSource = dtFiltered;
