    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;
    
    namespace DocuSignDotNet40
    {
      public partial class SignatureForm : Form
      {
        protected const string _username = ""; //Enter Username here
        protected const string _integratorKey = ""; //Enter Integrator Key here
        protected const string _password = ""; //Enter Password here
        protected const string _baseUri = "https://demo.docusign.net/restapi"; //Enter baseUri here
        protected const string _accountId = ""; //Enter acountId here
        protected string _authHeader = "";
    
        private void CreateEnvelope_Click(object sender, EventArgs e)
        {
          string requestUrl = _baseUri + "/v2/accounts/" + _accountId + "/envelopes";
          var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
          httpWebRequest.Method = "Post";
          httpWebRequest.ContentType = "application/json";
          httpWebRequest.Headers.Add("X-DocuSign-Authentication", _authHeader);
    
          string jsonRequest = GetCreateEnvelopeJson();
          var data = Encoding.ASCII.GetBytes(jsonRequest);
          using (var stream = httpWebRequest.GetRequestStream())
          {
              stream.Write(data, 0, data.Length);
          }
          var response = (HttpWebResponse)httpWebRequest.GetResponse();
          using (StreamReader sr = new StreamReader(response.GetResponseStream()))
          {
              string responseJson = sr.ReadToEnd();
              // more stuff
          }
        }
    
        public string GetCreateEnvelopeJson()
        {
          return @"{
           	'emailSubject': 'Please sign the agreement',
           	'status': 'sent',
               'recipients': {
                   'signers': [
                       {
                           'email': 'janedoe@acme.com',
                           'name': 'jane doe',
                           'recipientId': 1,
                           'tabs': {
                               'signHereTabs': [
                                   {
                                       'documentId': '1',
                                       'pageNumber': '1',
                                       'xPosition': '80',
                                       'yPosition': '80',
                                   }
                               ]
                           }
                       }
                   ]
               },
               'documents': [
                   {
                       'documentId': '1',
                       'name': 'Contract',
                       'fileExtension': 'txt',
                       'documentBase64': 'RG9jIFRXTyBUV08gVFdP'
                   }
               ]
           }";
        }
        public void GetEnvelope()
        {
            string envelopeId = "";//Enter EnvelopeId here
            if(string.IsNullOrWhiteSpace(envelopeId)) throw new ApplicationException("Invalid Envelope Id");
    
            string requestUrl = _baseUri + "/v2/accounts/" + _accountId +"/envelopes/" + envelopeId ;
            var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
            httpWebRequest.Method = "Get";
            httpWebRequest.Headers.Add("X-DocuSign-Authentication", _authHeader);
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                string responseJson = sr.ReadToEnd();
                // more stuff
            }
    
        }
        public SignatureForm()
        {
          InitializeComponent();
          
          if (string.IsNullOrWhiteSpace(_username)) throw new ApplicationException("Invalid _username");
          if (string.IsNullOrWhiteSpace(_integratorKey)) throw new ApplicationException("Invalid _integratorKey");
          
          if (string.IsNullOrWhiteSpace(_password)) throw new ApplicationException("Invalid _password");
          if (string.IsNullOrWhiteSpace(_baseUri)) throw new ApplicationException("Invalid _baseUri");
          if (string.IsNullOrWhiteSpace(_accountId)) throw new ApplicationException("Invalid _accountId");
          _authHeader = "{\"Username\":\"" + _username + "\", \"Password\":\"" + _password + "\", \"IntegratorKey\":\"" + _integratorKey + "\"}";
        }		
      }
    }
