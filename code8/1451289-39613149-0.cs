     var icdList = labRequests.ICDCodes.Select(t => new ICDCodeList()
                                            {
                                                ICDCodeId = t.ICDCodeId,
                                                ICDCode = t.ICDCodeName,
                                                ICDDescription = t.ICDDescription,
                                                ICDCodeType = t.ICDCodeType
                                            }).ToArray();        
           
