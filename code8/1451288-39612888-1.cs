        var finalResult =
        labRequestItem.LabTest.Select(p=>p.LabTestICDCodes= labRequests.ICDCodes.Select(t => new ICDCodeList()
                                        {
                                            ICDCodeId = t.ICDCodeId,
                                            ICDCode = t.ICDCodeName,
                                            ICDDescription = t.ICDDescription,
                                            ICDCodeType = t.ICDCodeType
                                        }).ToArray()).ToList();
