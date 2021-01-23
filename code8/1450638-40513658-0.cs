        public int PostTestResultObj(List<TestAndSampleResult> testandsampleresult)
        {
            long testResultId = 0;
            if (testandsampleresult != null)
                foreach (TestAndSampleResult orderdet in testandsampleresult)
                {
                    if (orderdet.TestResult != null) //Making sure our results object is passing null
                    {
                        mdlTestResult NewTestResult = new mdlTestResult
                        {
                            iOutletStorageId = orderdet.TestResult.iOutletStorageId,
                            dLastDeliveryDate = orderdet.TestResult.dLastDeliveryDate,
                            szMarkingCertificate = orderdet.TestResult.szMarkingCertificate,
                            iFirstResultId = orderdet.TestResult.iFirstResultId,
                            iSecondResultId = orderdet.TestResult.iSecondResultId,
                            szFirstResultRemark = orderdet.TestResult.szFirstResultRemark,
                            szSecondResultRemark = orderdet.TestResult.szSecondResultRemark,
                            szSiteVisitNo = orderdet.TestResult.szSiteVisitNo,
                            dTransdate = orderdet.TestResult.dTransdate,
                            iOutletId = orderdet.TestResult.iOutletId
                        };
                        //Persist the result
                        DataTable mydtTransReslt = Uow.tresult.GetTestResultNo(NewTestResult.iOutletStorageId,
                                                            NewTestResult.dLastDeliveryDate,
                                                            NewTestResult.szMarkingCertificate,
                                                            NewTestResult.iFirstResultId,
                                                            NewTestResult.iSecondResultId,
                                                            NewTestResult.szFirstResultRemark,
                                                            NewTestResult.szSecondResultRemark,
                                                            NewTestResult.szSiteVisitNo,
                                                            NewTestResult.dTransdate,
                                                            NewTestResult.iOutletId);
                        
                        testResultId = 0;
                        if (mydtTransReslt.Rows.Count > 0) //Result inserted successfully
                        {
                            //Get the id of new result
                            testResultId = Convert.ToInt32(mydtTransReslt.Rows[0]["NewPPMSTestResult"]);
                            if (testResultId > 0)//Result insert was successful
                            {
                                if (orderdet.MySampleCollections != null && testResultId > 0) //Samples have been passed from client
                                {
                                    foreach (SampleCollection Sample in orderdet.MySampleCollections)
                                    {
                                        long samples = Uow.spleCollections.GetSampleCollectionsNo(testResultId,
                                                                            //newsamplecollectionmodel.iPPMSTestResultId,
                                                                            Sample.iSampleTypeId,
                                                                            Sample.szLabelNumber,
                                                                            Sample.iSampleQty,
                                                                            Sample.szSerialNumber,
                                                                            Sample.szRecievedBy);
                                    }
                                }
                            }
                            else
                            {
                                mydtTransReslt.Columns.Add("Exception", typeof(string));
                                mydtTransReslt.Rows.Add("Sorry!!! Transaction Failed");
                            }
                        }
                    }
                }
            return 1;
        }
           
        
