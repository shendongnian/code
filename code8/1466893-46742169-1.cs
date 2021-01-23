    using Google.Apis.Calendar.v3;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using System;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using Google.Apis.Calendar.v3.Data;
    
    namespace GoogleSamplecSharpSample.Calendarv3.Auth
    {
    
       
    
        public static class ServiceAccountExample
        {
    
            /// <summary>
            /// Authenticating to Google calender using a Service account
            /// Documentation: https://developers.google.com/accounts/docs/OAuth2#serviceaccount
            /// </summary>
            /// Both param pass from webform1.aspx page on page load
            /// <param name="serviceAccountEmail">From Google Developer console https://console.developers.google.com/projectselector/iam-admin/serviceaccounts </param>
            /// <param name="serviceAccountCredentialFilePath">Location of the .p12 or Json Service account key file downloaded from Google Developer console https://console.developers.google.com/projectselector/iam-admin/serviceaccounts </param>
            /// <returns>AnalyticsService used to make requests against the Analytics API</returns>
    
            public static CalendarService AuthenticateServiceAccount(string serviceAccountEmail, string serviceAccountCredentialFilePath, string[] scopes)
    		{
                try
                {
                    if (string.IsNullOrEmpty(serviceAccountCredentialFilePath))
                        throw new Exception("Path to the service account credentials file is required.");
                    if (!File.Exists(serviceAccountCredentialFilePath))
                        throw new Exception("The service account credentials file does not exist at: " + serviceAccountCredentialFilePath);
                    if (string.IsNullOrEmpty(serviceAccountEmail))
                        throw new Exception("ServiceAccountEmail is required.");
                   
                    // For Json file
                    if (Path.GetExtension(serviceAccountCredentialFilePath).ToLower() == ".json")
                    {
                        GoogleCredential credential;
                        //using(FileStream stream = File.Open(serviceAccountCredentialFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        
    
                        using (var stream = new FileStream(serviceAccountCredentialFilePath, FileMode.Open, FileAccess.Read))
                        {
                            credential = GoogleCredential.FromStream(stream)
                                 .CreateScoped(scopes).CreateWithUser("xyz@gmail.com");//put a email address from which you want to send calendar its like (calendar by xyz user )
                        }
                       
                        // Create the  Calendar service.
                        return new CalendarService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = "Calendar_Appointment event Using Service Account Authentication",
                        });
                    }
                    else if (Path.GetExtension(serviceAccountCredentialFilePath).ToLower() == ".p12")
                    {   // If its a P12 file
    
                        var certificate = new X509Certificate2(serviceAccountCredentialFilePath, "notasecret", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                        var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
                        {
                            Scopes = scopes
                        }.FromCertificate(certificate));
    
                        // Create the  Calendar service.
                        return new CalendarService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = "Calendar_Appointment event Using Service Account Authentication",
    
                        });
                    }
                    else
                    {
                        throw new Exception("Something Wrong With Service accounts credentials.");
                    }
    
                }
                catch (Exception ex)
                {                
                    throw new Exception("Create_Service_Account_Calendar_Failed", ex);
                }
            }
    
           
        }
    }
