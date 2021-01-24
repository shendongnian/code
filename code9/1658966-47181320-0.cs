             ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = (System.Configuration.ConfigurationManager.AppSettings["Authorize-Live"].ToUpper() == "TRUE" ? AuthorizeNet.Environment.PRODUCTION : AuthorizeNet.Environment.SANDBOX);
            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = (System.Configuration.ConfigurationManager.AppSettings["Authorize-Live"].ToUpper() == "TRUE" ? System.Configuration.ConfigurationManager.AppSettings["Authorize-LoginID"] : System.Configuration.ConfigurationManager.AppSettings["Authorize-LoginID-SandBox"]),
                ItemElementName = ItemChoiceType.transactionKey,
                Item = (System.Configuration.ConfigurationManager.AppSettings["Authorize-Live"].ToUpper() == "TRUE" ? System.Configuration.ConfigurationManager.AppSettings["Authorize-TransactionKey"] : System.Configuration.ConfigurationManager.AppSettings["Authorize-TransactionKey-SandBox"])
            };
            if (paymentNonce.Trim() != "")
            {
                //set up data based on transaction
                var opaqueData = new opaqueDataType { dataDescriptor = "COMMON.ACCEPT.INAPP.PAYMENT", dataValue = paymentNonce };
                //standard api call to retrieve response
                var paymentType = new paymentType { Item = opaqueData };
                var transactionRequest = new transactionRequestType
                {
                    transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // authorize and capture transaction
                    amount = paymentAmount,
                    payment = paymentType,
                    customer = new customerDataType()
                    {
                        type = customerTypeEnum.individual,
                        id = "YOUR_DB_USERID"
                    },
                    profile = new customerProfilePaymentType()
                    {
                        createProfile = false
                    }
                };
                var request = new createTransactionRequest { transactionRequest = transactionRequest };
                // instantiate the contoller that will call the service
                var controller = new createTransactionController(request);
                const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
                const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
                ServicePointManager.SecurityProtocol = Tls12;
                controller.Execute();
                // get the response from the service (errors contained if any)
                var response = controller.GetApiResponse();
                //validate
                if (response != null)
                {
                    if (response.messages.resultCode == messageTypeEnum.Ok)
                    {
                        if (response.transactionResponse.messages != null)
                        {
                            responseData.Success = true;
                            transactionID = response.transactionResponse.transId;
							
                            string merchID = "STORED AUTHORIZE.NET CUSTOMERID, return blank string if none!";
                            var opaqueData2 = new opaqueDataType { dataDescriptor = "COMMON.ACCEPT.INAPP.PAYMENT", dataValue = paymentNonce2 };
                            //standard api call to retrieve response
                            var paymentType2 = new paymentType { Item = opaqueData2 };
                            customerPaymentProfileType opaquePaymentProfile = new customerPaymentProfileType();
                            opaquePaymentProfile.payment = paymentType2;
                            opaquePaymentProfile.customerType = customerTypeEnum.individual;
                            if (merchID == "")
                            {
								// CREATE NEW AUTH.NET AIM CUSTOMER
                                List<customerPaymentProfileType> paymentProfileList = new List<customerPaymentProfileType>();
                                paymentProfileList.Add(opaquePaymentProfile);
                                customerProfileType customerProfile = new customerProfileType();
                                customerProfile.merchantCustomerId = "YOUR_DB_USERID";
                                
                                customerProfile.paymentProfiles = paymentProfileList.ToArray();
                                var cimRequest = new createCustomerProfileRequest { profile = customerProfile, validationMode = validationModeEnum.none };
                                var cimController = new createCustomerProfileController(cimRequest);          // instantiate the contoller that will call the service
                                cimController.Execute();
                                createCustomerProfileResponse cimResponse = cimController.GetApiResponse();
                                if (cimResponse != null && cimResponse.messages.resultCode == messageTypeEnum.Ok)
                                {
                                    if (cimResponse != null && cimResponse.messages.message != null)
                                    {
										// STORE cimResponse.customerProfileId IN DATABASE FOR USER
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < cimResponse.messages.message.Length; i++)
                                        Utility.AppendTextToFile("New Error (" + merchID + ") #" + i.ToString() + ": " + cimResponse.messages.message[i].code + "  " + cimResponse.messages.message[i].text, Server.MapPath("/pub/auth.txt"));
                                }
                            }
                            else
                            {
								// ADD PAYMENT PROFILE TO EXISTING AUTH.NET AIM CUSTOMER
                                var cimRequest = new createCustomerPaymentProfileRequest
                                {
                                    paymentProfile = opaquePaymentProfile,
                                    validationMode = validationModeEnum.none,
                                    customerProfileId = merchID.Trim()
                                };
                                var cimController = new createCustomerPaymentProfileController(cimRequest);
                                cimController.Execute();
                                //Send Request to EndPoint
                                createCustomerPaymentProfileResponse cimResponse = cimController.GetApiResponse();
                                if (cimResponse != null && cimResponse.messages.resultCode == messageTypeEnum.Ok)
                                {
                                    if (cimResponse != null && cimResponse.messages.message != null)
                                    {
                                        //Console.WriteLine("Success, createCustomerPaymentProfileID : " + response.customerPaymentProfileId);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < cimResponse.messages.message.Length; i++)
                                        Utility.AppendTextToFile("Add Error  (" + merchID + ") #" + i.ToString() + ": " + cimResponse.messages.message[i].code + "  " + cimResponse.messages.message[i].text, Server.MapPath("/pub/auth.txt"));
                                }
                            }
                        }
                        else
                        {
                            responseData.Message = "Card Declined";
                            responseData.Success = false;
                            if (response.transactionResponse.errors != null)
                            {
                                responseData.Message = response.transactionResponse.errors[0].errorText;
                            }
                        }
                    }
                    else
                    {
                        responseData.Message = "Failed Transaction";
                        responseData.Success = false;
                        if (response.transactionResponse != null && response.transactionResponse.errors != null)
                        {
                            responseData.Message = response.transactionResponse.errors[0].errorText;
                        }
                        else
                        {
                            responseData.Message = response.messages.message[0].text;
                        }
                    }
                }
                else
                {
                    responseData.Message = "Failed Transaction, Try Again!";
                    responseData.Success = false;
                }
            }
            else
            {
				// RUN PAYMENT WITH STORED PAYMENT PROFILE ID
                customerProfilePaymentType profileToCharge = new customerProfilePaymentType();
                profileToCharge.customerProfileId = CustomerID;
                profileToCharge.paymentProfile = new paymentProfile { paymentProfileId = PaymentID };
                var transactionRequest = new transactionRequestType
                {
                    transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    
                    amount = paymentAmount,
                    profile = profileToCharge
                };
                var request = new createTransactionRequest { transactionRequest = transactionRequest };
                // instantiate the collector that will call the service
                var controller = new createTransactionController(request);
                controller.Execute();
                // get the response from the service (errors contained if any)
                var response = controller.GetApiResponse();
                //validate
                if (response != null)
                {
                    if (response.messages.resultCode == messageTypeEnum.Ok)
                    {
                        if (response.transactionResponse.messages != null)
                        {
                            responseData.Success = true;
                            transactionID = response.transactionResponse.transId;
                        }
                        else
                        {
                            responseData.Message = "Card Declined";
                            responseData.Success = false;
                            if (response.transactionResponse.errors != null)
                            {
                                responseData.Message = response.transactionResponse.errors[0].errorText;
                            }
                        }
                    }
                    else
                    {
                        responseData.Message = "Failed Transaction";
                        responseData.Success = false;
                        if (response.transactionResponse != null && response.transactionResponse.errors != null)
                        {
                            responseData.Message = response.transactionResponse.errors[0].errorText;
                        }
                        else
                        {
                            responseData.Message = response.messages.message[0].text;
                        }
                    }
                }
                else
                {
                    responseData.Message = "Failed Transaction, Try Again!";
                    responseData.Success = false;
                }
            }
