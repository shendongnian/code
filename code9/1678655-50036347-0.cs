            DataConnectionDialog dcd = new DataConnectionDialog();
            DataProvider dataProviderSql = DataProvider.SqlDataProvider;
            DataSource dataSourceSql = new DataSource(dataProviderSql.Name, dataProviderSql.DisplayName);
            dataSourceSql.Providers.Add(dataProviderSql);
            DataProvider dataProviderOracle = DataProvider.OracleDataProvider;
            DataSource dataSourceOracle = new DataSource(dataProviderOracle.Name, dataProviderOracle.DisplayName);
            dataSourceOracle.Providers.Add(dataProviderOracle);
            DataProvider dataProviderOle = DataProvider.OleDBDataProvider;
            DataSource dataSourceOle = new DataSource(dataProviderOle.Name, dataProviderOle.DisplayName);
            dataSourceOle.Providers.Add(dataProviderOle);
            DataProvider dataProviderOdbc = DataProvider.OdbcDataProvider;
            DataSource dataSourceOdbc = new DataSource(dataProviderOdbc.Name, dataProviderOdbc.DisplayName);
            dataSourceOdbc.Providers.Add(dataProviderOdbc);
            dcd.DataSources.Add(dataSourceSql);
            dcd.DataSources.Add(dataSourceOracle);
            dcd.DataSources.Add(dataSourceOle);
            dcd.DataSources.Add(dataSourceOdbc);
            dcd.SelectedDataSource = dataSourceSql;
            dcd.SelectedDataProvider = dataProviderSql;
            if (DataConnectionDialog.Show(dcd) == System.Windows.Forms.DialogResult.OK)
            {
                System.Windows.MessageBox.Show("YES");
            }
