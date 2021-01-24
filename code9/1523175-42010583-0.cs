    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq; 
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.Deployment.WindowsInstaller;
    namespace myCompanyAgentSetup.WixExtension
    {
    public static class myCompanyAgentSetupWixExtension
    {
        [CustomAction]
        public static ActionResult Execute(Session session)
        {
            var errorMsg = string.Empty;
            var record = new Record();
            var token = Environment.GetEnvironmentVariable("RX_JOB_NO");
            var restUser = session["RESTUSER"];
            var restPass = session["RESTPASS"];
            var restUrl = string.Format(session["RESTURL"], token);
            
            var request = (HttpWebRequest)WebRequest.Create(restUrl);
            var encoded = Convert.ToBase64String(Encoding.Default.GetBytes(restUser + ":" + restPass));
            request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + encoded);
            request.Credentials = new NetworkCredential(restUser, restPass);
            Console.WriteLine("attempting to get API Key");
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode.ToString() != "OK")
                {
                    record = new Record
                    {
                        FormatString = string.Format(response.StatusDescription)
                    };
                    session.Message(InstallMessage.Error, record);
                    Console.WriteLine("Unable to get API Key");
                    Console.WriteLine("Adding RX_CLOUDBACKUP_API Environment Variable with no value");
                    UpdateConfigFiles("");
                }
                else
                {
                    var apiKey = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    if (apiKey.Contains("Error"))
                    {
                        record = new Record
                        {
                            FormatString = string.Format(apiKey)
                        };
                        session.Message(InstallMessage.Error, record);
                        session.Message(InstallMessage.Terminate, record);
                    }
                    Console.WriteLine("Adding RX_CLOUDBACKUP_API with value - " + apiKey);
                    UpdateConfigFiles(apiKey);
                   
                    return ActionResult.Success;
                }
            }
            catch (Exception e)
            {
                record = new Record
                {
                    FormatString = string.Format(e.Message)
                };
                session.Message(InstallMessage.Error, record);
                session.Message(InstallMessage.Terminate, record);
            }
            //An error has occurred, set the exception property and return failure.
            session.Log(errorMsg);
            session["CA_ERRORMESSAGE"] = errorMsg;
            record = new Record
            {
                FormatString = string.Format("Something has gone wrong!")
            };
            session.Message(InstallMessage.Error, record);
            session.Message(InstallMessage.Terminate, record);
            return ActionResult.Failure;
        }
        private static void UpdateConfigFiles(string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                Environment.SetEnvironmentVariable("RX_CLOUDBACKUP_API", null, EnvironmentVariableTarget.Machine);
                Environment.SetEnvironmentVariable("RX_CLOUDBACKUP_API", apiKey, EnvironmentVariableTarget.Machine);
            }
            else
            {
                Environment.SetEnvironmentVariable("RX_CLOUDBACKUP_API", "", EnvironmentVariableTarget.Machine);
            }
            
        }
    }
