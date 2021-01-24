    using (SqlConnection connectionhub = new SqlConnection(HubConnection))
    using (SqlConnection connection = new SqlConnection(PMConnection))
    {
        connectionhub.Open();
        connection.Open();
        SqlCommand command3 = new SqlCommand(@"
            SELECT distinct(table1.name) as 'Symbol',
                   table2.Segment as 'Segment',
                   table2.AllocationAmount as 'AllocationAmount',
                   table2.PX_LAST as 'Price', 
                   table1.CUR_MKT_CAP as 'CMC',
                   table1.FCFY_WITH_CUR_MKT_CAP as 'FCMC',
                   table1.ROIC as 'ROIC', 
                   table1.ROICDELTA as 'ROICD' 
              FROM View_REIT_Model_And_Holdings as table1
                    INNER JOIN [MostRecentlyInModelSelected] as table2
                        ON table1.name = table2.Ticker
             WHERE table1.AllocationAmount != -1 
               AND NOT EXISTS (SELECT NULL 
                                 FROM [ViewPCData] as table3 
                                WHERE table1.name = table3.Symbol 
                                  AND table2.Segment = table3.SubsectorDescription 
                                  AND table3.Objective = 'REITS' 
                                  AND table3.SectorDescription != 'NULL' 
                                  AND table3.SubsectorDescription != 'NULL')",
                                                    connectionreit);
        command3.CommandType = CommandType.Text;
        SqlCommand command4 = new SqlCommand(@"
            SELECT PortfolioAccountNumber, 
                   PortfolioDescription, 
                   SUM(TotalValue) as 'TotalValue' 
              FROM [ViewPCData] 
             WHERE Objective = 'REITS' 
             GROUP BY PortfolioAccountNumber, PortfolioDescription", connection);
        command4.CommandType = CommandType.Text;
        var stocksDS = new DataSet();
        var stocksDA = new System.Data.SqlClient.SqlDataAdapter();
        stocksDA.SelectCommand = command3
        stocksDA.Fill(stocksDS, "stocks");
        var acctsDS = new DataSet();
        var acctsDA = new System.Data.SqlClient.SqlDataAdapter();
        acctsDA.SelectCommand = command4
        acctsDA.Fill(acctsDS, "accts");
        var stocks = stocksDS.Tables["stocks"].AsEnumerable();
        var accts = acctsDS.Tables["accts"].AsEnumerable();
        var results = (from stocksDR in stocks
                       from acctsDR in accts
                       select new BuySellModel {
                            PortfolioAccount = acctsDR["PortfolioAccountNumber"],
                            PortfolioDescription = acctsDR["PortfolioAccountDescription"],
                            AccountAmount = acctsDR["TotalValue"],
                            Symbol = stocksDR["Symbol"],
                            Segment = stocksDR["Segment"],
                            AllocationAmount = stocksDR["AllocationAmount"],
                            Price = stocksDR["Price"],
                            MarketValue = stocksDR["CMC"],
                            FCFY = stocksDR["FCMC"],
                            ROIC = stocksDR["ROIC"],
                            ROICdelta = stocksDR["ROICD"],
                            Buy = true
                        });
        
        foreach (BySellModel buy in results) {
            accountBuys.Add(buy);
        }
        connectionhub.Close();
        connection.Close();
    }
