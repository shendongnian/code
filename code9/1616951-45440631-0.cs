                SqlCommand cmdDetail = new SqlCommand(SQL_SubSytemsToCapability, DBConDetail);
                SqlDataReader rdrDetail = cmdDetail.ExecuteReader();
                List<relatedCapility> RLCaps = new List<relatedCapility>();
                List<relatedCapabilitySystem> RLCapSys = new List<relatedCapabilitySystem>();
                string lastCapShown = null;
                while (rdrDetail.Read())
                {
                    if (lastCapShown != rdrDetail["CAPName"].ToString())
                    {
                        RLCapSys = relatedCapabilitySystemList();
                        relatedCapility rC = new relatedCapility
                        {
                            Capability = rdrDetail["CAPName"].ToString(),
                            systemsRelated = RLCapSys,
                        };
                        RLCaps.Add(rC);
                    }
                    relatedCapabilitySystem rCs = new relatedCapabilitySystem
                    {
                        system = rdrDetail["name"].ToString(),
                        start = rdrDetail["SysStart"].ToString(),
                        end = rdrDetail["SysEnd"].ToString(),
                    };
                    RLCapSys.Add(rCs);
                    // method to compare the last related Capability shown create a new related Capabilty entry or add to the existing releated Capabilty related system list
                    lastCapShown = rdrDetail["CAPName"].ToString();
 
                }
                DBConDetail.Close();
