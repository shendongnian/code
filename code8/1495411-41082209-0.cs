            SqlParameter sqlParaFaction_Faction_ID = new SqlParameter("@Faction_ID", SqlDbType.Int);
            SqlParameter sqlParaFaction_ToFactionID = new SqlParameter("@ToFaction_ID", SqlDbType.Int);
            SqlParameter sqlParaFaction_Standing = new SqlParameter("@Standing", SqlDbType.SmallInt);
            using (SqlConnection sqlCnn = new SqlConnection(sqlCnnString))
            {
                sqlCnn.Open();
                using (SqlTransaction sqlTrans = sqlCnn.BeginTransaction())
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = sqlCnn;
                        string sqlCmdFactionStandings = "INSERT INTO FactionStandings (Faction_ID, ToFaction_ID, Standing) VALUES (@Faction_ID, @ToFaction_ID, @Standing)";
                        sqlCmd.CommandText = sqlCmdFactionStandings;
                        sqlCmd.Transaction = sqlTrans;
                        sqlCmd.Parameters.Add(sqlParaFaction_Faction_ID);
                        sqlCmd.Parameters.Add(sqlParaFaction_ToFactionID);
                        sqlCmd.Parameters.Add(sqlParaFaction_Standing);
                        foreach (FactionStanding factionStanding in faction.FactionStandings)
                        {
                            //
                            // - Insert Faction Standing Table Data
                            //
                            sqlParaFaction_Faction_ID.Value = factionStanding.Faction_ID; 
                            sqlParaFaction_ToFactionID.Value = factionStanding.ToFaction_ID;
                            sqlParaFaction_Standing.Value = factionStanding.DefaultStanding;
                            sqlCmd.ExecuteNonQuery();
                        }
                        sqlTrans.Commit();
                    }
                }
            }
        }
