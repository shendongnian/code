             public bool ValidateData(DataTable dtData)
                {
                    bool isValid = true;
                    try
                    {
        
                        for (int i = 0; i < dtData.Rows.Count; i++)
                        {
                            string MANDATE_DATE = Convert.ToString(dtData.Rows[i]["MANDATE_DATE"]);
                            //string SPONSOR_BANK_CODE = Convert.ToString(dtData.Rows[i]["SPONSOR_BANK_CODE"]);
                            //string UTILITY_BILLER_COMPANY_BANK = Convert.ToString(dtData.Rows[i]["UTILITY_BILLER_COMPANY_BANK"]);
                            //string ACTION = Convert.ToString(dtData.Rows[i]["ACTION"]);
                            string AC_TYPE = Convert.ToString(dtData.Rows[i]["AC_TYPE"]);
                            string LEGAL_ACCOUNT_NUMBER = Convert.ToString(dtData.Rows[i]["LEGAL_ACCOUNT_NUMBER"]);
                            string DESTINATION_BANK_BRANCH = Convert.ToString(dtData.Rows[i]["DESTINATION_BANK_BRANCH"]);
                            string MICR_CODE = Convert.ToString(dtData.Rows[i]["MICR_CODE"]);
                            //string IFSC_CODE = Convert.ToString(dtData.Rows[i]["IFSC_CODE"]);
                            string DEBIT_MAXAMT = Convert.ToString(dtData.Rows[i]["DEBIT_MAXAMT"]);
                            string CUSTOMER_REFERENCE = Convert.ToString(dtData.Rows[i]["CUSTOMER_REFERENCE"]);
                            string CUSTOMER_FRQCY = Convert.ToString(dtData.Rows[i]["CUSTOMER_FRQCY"]);
                            string START_DATE = Convert.ToString(dtData.Rows[i]["START_DATE"]);
                            // string END_DATE = dtData.Rows[i]["Mobile No#"]);
                            string CUSTOMER_NAME = Convert.ToString(dtData.Rows[i]["CUSTOMER_NAME"]);
        
                            if (MANDATE_DATE == "" || AC_TYPE == "" || LEGAL_ACCOUNT_NUMBER == "" || DESTINATION_BANK_BRANCH == "" || MICR_CODE == "" || DEBIT_MAXAMT == "" || CUSTOMER_REFERENCE == "" || CUSTOMER_FRQCY == "" || START_DATE == "" || CUSTOMER_NAME == "")
                            {
                                SchedulerErrorLog_("Mandatory field is blank", "Function: testTimer_Elapsed (ValidateData)");
                                //ErrorLog(product_Name, path, "Failure", "File name  " + path + " Data is not validate.", "");
                                return isValid = false;
                            }
                        }
        
                        if (!isValid)
                        {
                            //dtExport = dtData.Copy();`enter code here`
                        }
                    }
                    catch (Exception ex)
                    {
                        SchedulerErrorLog_(ex.Message.ToString(), ex.StackTrace.ToString());
                        //ErrorLog(product_Name, path, "Failure", "File name  " + path + " Data is not validate." + ex.ToString() + "", "");
                        throw ex;
                    }
                    return isValid;
                }
