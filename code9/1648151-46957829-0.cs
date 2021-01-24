        // Enter your credentials
        public static string username = "guid";
        public static string password = "string";
        public static string integratorKey = "guid";
        public static string loginEndpoint = "https://demo.docusign.net/restapi";// for production change to www.docusign.net/restapi
        public static string gatewayAccountId = "guid";
        public static string recipId = null;
        public static string PaymentReceiptTabId = null;
        public static string PaymentFormulaTabId = null;
        public static string templateId = "guid";
        public static string baseURL = "https://demo.docusign.net/restapi/v2/accounts/#######"
        GetRecipientId();
        public static string CreateEnvelope()
        {
            string RV = null;
            try
            {
                string url = baseURL + "/envelopes";
                string xmlRequestBody =
                    "<envelopeDefinition xmlns=\"http://www.docusign.com/restapi\">" +
                        "<status>created</status>" +
                          "<emailSubject>Turner Pest Control - Termite Bond Quote</emailSubject>" +
                          "<templateId>" + templateId + "</templateId>" +
                          "<templateRoles>" +
                            "<templateRole>" +
                              "<name>" + custName + "</name>" +
                              "<email>" + custEmail + "</email>" +
                              "<roleName>Customer</roleName>" +
                              "<tabs>" +
                                "<textTabs>" +
                                  "<text>" +
                                    "<tabLabel>txtPropAddr</tabLabel>" +
                                    "<value>" + txtPropAddr.TrimEnd() + "</value>" +
                                  "</text>" +
                                  "<text>" +
                                    "<tabLabel>txtPropZip</tabLabel>" +
                                    "<value>" + txtPropZip + "</value>" +
                                  "</text>" +
                                "</textTabs>" +
                                "<numberTabs>" +
                                    "<number>" +
                                        "<documentId>1</documentId>" +
                                        "<pageNumber>1</pageNumber>" +
                                        "<recipientId>" + recipId + "</recipientId>" +
                                        "<tabLabel>TPCPaymentCustom</tabLabel>" +
                                        "<locked>true</locked>" +
                                        "<required>false</required>" +
                                        "<value>" + txtPayment + "</value>" +
                                        "<isPaymentAmount>false</isPaymentAmount>" +
                                    "</number>" +
                                "</numberTabs>" +
                              "</tabs>" +
                            "</templateRole>" +
                            "<templateRole>" +
                              "<name>" + repName + "</name>" +
                              "<email>" + repEmail + "</email>" +
                              "<roleName>SalesRep</roleName>" +
                            "</templateRole>" +
                        "</templateRoles>" +
                    "</envelopeDefinition>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlRequestBody);
                HttpWebRequest request = initializeRequest(url, "POST", doc.OuterXml, username, password, integratorKey);
                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(resp.GetResponseStream());
                    xmldoc.Save("C:\\Temp\\DocuSign\\CreateEnvelopeResponse.xml");// FOR TESTING ONLY
                    XmlNodeList xnList = xmldoc.GetElementsByTagName("envelopeSummary");
                    foreach (XmlNode xn in xnList)
                    {
                        string status = xn["status"].InnerText;
                        if (status == "created")
                        {
                            string envelopeId = xn["envelopeId"].InnerText;
                            GetFormulaTabIds();
                            if (UpdateEnvelopeFormulas())
                            {
                                if (UpdateEnvelopeStatus())
                                {
                                    RV = envelopeId;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    {
                        string text = new StreamReader(data).ReadToEnd();
                        XDocument doc = XDocument.Parse(text);
                        SmtpEmailSend(httpResponse.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                SmtpEmailSend("CreateEnvelope() Error!");
            }
            return RV;
        }
        public static bool UpdateEnvelopeFormulas()
        {
            bool RV = false;
            try
            {
                string url = baseURL + "/envelopes/" + envelopeId + "/recipients/1/tabs";
                string xmlRequestBody =
                    "<tabs xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.docusign.com/restapi\">" +
                        "<formulaTabs xmlns:a=\"http://schemas.datacontract.org/2004/07/API_REST.Models\">" +
                            "<a:formulaTab>" +
                                "<documentId>1</documentId>" +
                                "<pageNumber>1</pageNumber>" +
                                "<recipientId>1</recipientId>" +
                                "<tabId>" + PaymentReceiptTabId + "</tabId>" +
                                "<tabLabel>PaymentReceipt c6d38477-62a4-4a03-adc1-671456278ecf</tabLabel>" +
                                "<locked>true</locked>" +
                                "<required>true</required>" +
                                "<a:formula>([PaymentFormula 4354e223-fb2e-44ed-81e4-385b40eb81f6]) * 100</a:formula>" +
                                "<a:hidden>true</a:hidden>" +
                                "<a:isPaymentAmount>false</a:isPaymentAmount>" +
                                "<a:paymentDetails>" +
                                    "<currencyCode>USD</currencyCode>" +
                                    "<gatewayAccountId>" + gatewayAccountId + "</gatewayAccountId>" +
                                    "<gatewayDisplayName>Stripe</gatewayDisplayName>" +
                                    "<gatewayName>stripe</gatewayName>" +
                                    "<lineItems xmlns:b=\"http://schemas.datacontract.org/2004/07/API_REST.Models.v2.payments\">" +
                                        "<b:paymentLineItem>" +
                                            "<b:amountReference>PaymentFormula 4354e223-fb2e-44ed-81e4-385b40eb81f6</b:amountReference>" +
                                            "<b:description>CustNum[" + custNo + "]</b:description>" +
                                            "<b:itemCode>PolicyNum[" + policyNum + "]</b:itemCode>" +
                                            "<b:name>" + warrantyType + "</b:name>" +
                                        "</b:paymentLineItem>" +
                                    "</lineItems>" +
                                    "<status>new</status>" +
                                "</a:paymentDetails>" +
                                "<a:roundDecimalPlaces>0</a:roundDecimalPlaces>" +
                            "</a:formulaTab>" +
                            "<a:formulaTab>" +
                                "<documentId>1</documentId>" +
                                "<pageNumber>1</pageNumber>" +
                                "<recipientId>1</recipientId>" +
                                "<tabId>" + PaymentFormulaTabId + "</tabId>" +
                                "<tabLabel>PaymentFormula 4354e223-fb2e-44ed-81e4-385b40eb81f6</tabLabel>" +
                                "<locked>true</locked>" +
                                "<required>true</required>" +
                                "<a:formula>[TPCPaymentCustom]</a:formula>" +
                                "<a:hidden>true</a:hidden>" +
                                "<a:isPaymentAmount>false</a:isPaymentAmount>" +
                                "<a:roundDecimalPlaces>2</a:roundDecimalPlaces>" +
                            "</a:formulaTab>" +
                        "</formulaTabs>" +
                    "</tabs>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlRequestBody);
                HttpWebRequest request = initializeRequest(url, "PUT", doc.OuterXml, username, password, integratorKey);
                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    XmlDocument xmldoc = new XmlDocument();// FOR TESTING ONLY
                    xmldoc.Load(resp.GetResponseStream());// FOR TESTING ONLY
                    xmldoc.Save("C:\\Temp\\DocuSign\\RecipientTabUpdateResponse.xml");// FOR TESTING ONLY
                    RV = true;
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    {
                        string text = new StreamReader(data).ReadToEnd();
                        SmtpEmailSend(httpResponse.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                SmtpEmailSend("UpdateEnvelopeFormula() Error!");
            }
            return RV;
        }
        public static bool UpdateEnvelopeStatus()
        {
            bool RV = false;
            try
            {
                string url = baseURL + "/envelopes/" + envelopeId;
                string xmlRequestBody =
                    "<envelope xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.docusign.com/restapi\">" +
                        "<status>sent</status>" +
                    "</envelope>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlRequestBody);
                HttpWebRequest request = initializeRequest(url, "PUT", doc.OuterXml, username, password, integratorKey);
                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    XmlDocument xmldoc = new XmlDocument();// FOR TESTING ONLY
                    xmldoc.Load(resp.GetResponseStream());// FOR TESTING ONLY
                    xmldoc.Save("C:\\Temp\\DocuSign\\EnvelopeStatusUpdateResponse.xml");// FOR TESTING ONLY
                    RV = true;
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    {
                        string text = new StreamReader(data).ReadToEnd();
                        SmtpEmailSend(httpResponse.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                SmtpEmailSend("UpdateEnvelopeStatus() Error!");
            }
            return RV;
        }
        //***************************************************
        // --- HELPER FUNCTIONS ---
        //***************************************************
        public static HttpWebRequest initializeRequest(string url, string method, string body, string email, string password, string intKey)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            addRequestHeaders(request, email, password, intKey);
            if (body != null)
                addRequestBody(request, body);
            return request;
        }
        public static void addRequestHeaders(HttpWebRequest request, string email, string password, string intKey)
        {
            string authenticateStr =
                "<DocuSignCredentials>" +
                    "<Username>" + username + "</Username>" +
                    "<Password>" + password + "</Password>" +
                    "<IntegratorKey>" + integratorKey + "</IntegratorKey>" +
                    "</DocuSignCredentials>";
            request.Headers.Add("X-DocuSign-Authentication", authenticateStr);
            request.Accept = "application/xml";
            request.ContentType = "application/xml";
        }
        public static void addRequestBody(HttpWebRequest request, string requestBody)
        {
            // create byte array out of request body and add to the request object
            byte[] body = System.Text.Encoding.UTF8.GetBytes(requestBody);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(body, 0, requestBody.Length);
            dataStream.Close();
        }
        public static string getResponseBody(HttpWebRequest request)
        {
            // read the response stream into a local string
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            string responseText = sr.ReadToEnd();
            return responseText;
        }
        public static void GetEnvelopeRecipientTabs()
        {
            string url = baseURL + "/envelopes/" + envelopeId + "/recipients?include_tabs=true";
            HttpWebRequest request = initializeRequest(url, "GET", null, username, password, integratorKey);
            XmlDocument xmldoc = new XmlDocument();
            using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
            {
                xmldoc.Load(resp.GetResponseStream());
                xmldoc.Save("C:\\Temp\\DocuSign\\EnvelopeRecipientsTabs.xml");// FOR TESTING ONLY
            }
        }
        public static void GetRecipientId()
        {
            string url = baseURL + "/templates/" + templateId + "/recipients";
            HttpWebRequest request = initializeRequest(url, "GET", null, username, password, integratorKey);
            using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(resp.GetResponseStream());
                xmldoc.Save("C:\\Temp\\DocuSign\\TemplateRecipients.xml");// FOR TESTING ONLY
                XmlNodeList xnList = xmldoc.GetElementsByTagName("signer");
                foreach (XmlNode xn in xnList)
                {
                    string roleName = xn["roleName"].InnerText;
                    if (roleName == "Customer")
                    {
                        // Get customer's recipientId
                        recipId = xn["recipientId"].InnerText;
                        break;
                    }
                }
            }
        }
        public static void GetFormulaTabIds()
        {
            string url = baseURL + "/envelopes/" + envelopeId + "/recipients/1/tabs";
            HttpWebRequest request = initializeRequest(url, "GET", null, username, password, integratorKey);
            using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(resp.GetResponseStream());
                xmldoc.Save("C:\\Temp\\DocuSign\\RecipientOneTabs.xml");// FOR TESTING ONLY
                XmlNodeList xnList = xmldoc.GetElementsByTagName("a:formulaTab");
                foreach (XmlNode xn in xnList)
                {
                    // Gets the tabId's for hidden formula tabs, which get inserted into the envelope, 
                    // when a "Payment Item" is dropped on a template, and the Payment Amount is set to a Formula.
                    string tabLabel = xn["tabLabel"].InnerText;
                    switch (tabLabel.Substring(0, 14))
                    {
                        case "PaymentReceipt":
                            PaymentReceiptTabId = xn["tabId"].InnerText;
                            break;
                        case "PaymentFormula":
                            PaymentFormulaTabId = xn["tabId"].InnerText;
                            break;
                    }
                }
            }
        }
  
