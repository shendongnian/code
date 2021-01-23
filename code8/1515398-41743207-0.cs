    DataResult<Fmd> resultConversion = null;
                    IdentifyResult identifyResult = null;
                    string MobileNumber = "";
                    string Cnic = "";
                    
                    // Check capture quality and throw an error if bad.
                    if (!this.CheckCaptureResult(captureResult)) return;
                    // See the SDK documentation for an explanation on threshold scores.
                    int thresholdScore = DPFJ_PROBABILITY_ONE * 1 / 100000;
                    DataSet dataSetBiometric = DatabaseHandler.getData("select CNIC, MOBILE_NUMBER, BIOMETRIC from ACCOUNT_OPENING");//select CNIC, MOBILE_NUMBER, BIOMETRIC from ACCOUNT_OPENING
                    Fmd[] fmds = new Fmd[dataSetBiometric.Tables[0].Rows.Count];
                    for (int i = 0; i < dataSetBiometric.Tables[0].Rows.Count; i++)
                    {
                        fmds[0] = Fmd.DeserializeXml(dataSetBiometric.Tables[0].Rows[i]["BIOMETRIC"].ToString());//BIOMETRIC
                        resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                        identifyResult = Comparison.Identify(resultConversion.Data, 0, fmds, thresholdScore, dataSetBiometric.Tables[0].Rows.Count);
                        if (identifyResult.ResultCode == Constants.ResultCode.DP_SUCCESS)
                        {
                            MobileNumber = dataSetBiometric.Tables[0].Rows[i]["MOBILE_NUMBER"].ToString();
                            Cnic = dataSetBiometric.Tables[0].Rows[i]["CNIC"].ToString();
                            break;
                        }
                    }
