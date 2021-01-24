    public void CreateLead( string title, decimal opportunity, string contactName, string phoneNumber, string email )
        {
            try
            {                
                string accessToken = GetNewAccessToken();
                
                string url = string.Format( "https://{0}/rest/crm.lead.add.json", portal_name );
                var data = new
                {
                    fields = new
                    {
                        TITLE = title,
                        CURRENCY_ID = "RUB",
                        STATUS_ID = "NEW",
                        OPENED = "Y",
                        OPPORTUNITY = opportunity,
                        ASSIGNED_BY_ID = 46,
                        COMPANY_TITLE = contactName,
                        PHONE =  new List<PHONE>() { new PHONE() { VALUE_TYPE = "WORK", TYPE_ID = "PHONE", VALUE = phoneNumber } }.ToArray(),
                        EMAIL = new List<EMAIL>() { new EMAIL() { VALUE_TYPE = "WORK", TYPE_ID = "EMAIL", VALUE = email } }.ToArray()
                    },
                    @params = new
                    {
                        REGISTER_SONET_EVENT = "Y"
                    }
                };
                BitrixLead lead = new BitrixLead();
                lead.TITLE = title;
                lead.CURRENCY_ID = "RUB";
                lead.STATUS_ID = "NEW";
                lead.OPENED = "Y";
                lead.OPPORTUNITY = opportunity.ToString();                
                if (!string.IsNullOrEmpty( contactName ))
                    lead.COMPANY_TITLE = contactName;
                if (!string.IsNullOrEmpty( phoneNumber ))
                    lead.PHONE = new List<PHONE>() { new PHONE() { VALUE_TYPE="WORK", TYPE_ID="PHONE", VALUE = phoneNumber }}.ToArray();
                if (!string.IsNullOrEmpty( email ))
                    lead.EMAIL = new List<EMAIL>() { new EMAIL() { VALUE_TYPE = "WORK", TYPE_ID = "EMAIL", VALUE = email } }.ToArray();
                PostToAPI( url, accessToken, data );
            }
            catch (Exception exc)
            {
            }
        }
    private void PostToAPI( string url, string token, object data )
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject( data );
            var http = (HttpWebRequest)WebRequest.Create( new Uri( url ) );
            http.Accept = "application/json; charset=utf-8";
            http.ContentType = "application/json; charset=utf-8";
            http.Method = "POST";            
            http.Headers.Add( "Authorization", "Bearer " + token );
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes( json );
            Stream newStream = http.GetRequestStream();
            newStream.Write( bytes, 0, bytes.Length );
            newStream.Close();
            var response = http.GetResponse();            
        }
