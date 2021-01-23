    var tempAllocation = new List<Object>();
        if (tempAllocationR.Count > 0 && tempAllocationV.Count > 0)
                        {
                            foreach (TempAllocation tv in tempAllocationV)
                            {
                                var rec = tempAllocationR.FirstOrDefault(tr => tr.TERR_ID == tv.TERR_ID && tr.TERR == tv.TERR && tr.Team == tv.Team);
                                if (rec != null)
                                {
                                    rec.Vyzulta = tv.Vyzulta;
                                }
                                else
                                {
                                    tempAllocationR.Add(tv);
                                }
        
                            }
                            tempAllocation = tempAllocationR;
                        }
                        else if (tempAllocationV.Count == 0 && tempAllocationR.Count > 0)
                        {
                            tempAllocation = tempAllocationR;
                        }
                        else if (tempAllocationR.Count == 0 && tempAllocationV.Count > 0)
                        {
                            tempAllocation = tempAllocationV;
                        }
