    using System;
    using GPP.Bot.DataAccessLayer;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using System.Web.Configuration;
    using Microsoft.SharePoint.Client;
    using Microsoft.SharePoint.Client.Utilities;
    
    namespace Gpp.Bot.ExceptionHandling
    {
        public class BotException
        {
            public static List<ErrorLogProperties> BOTErrorLog(string Environment, string exceptionStack, string exceptionSource, string fullException, string loggedInUser, string exceptionDateTime)
            {
    			// this code to capture data in Cutome DB
                return DbHelper.ExecuteList<ErrorLogProperties>(
                    new Command { ComandText = "Your Stored Procedure" },
                    new Parameter<string, object>("Environment", Environment),
                    new Parameter<string, object>("exceptionStack", exceptionStack),
                    new Parameter<string, object>("exceptionSource", exceptionSource),
                    new Parameter<string, object>("fullException", fullException),
                    new Parameter<string, object>("loggedInUser", loggedInUser),
                    new Parameter<string, object>("exceptionDateTime", exceptionDateTime)
                    );
    
            }
    
            public static async Task GenerateBotException(string LLID, Exception ex)
            {
               BotExceptionNotification(LLID.Split('*')[1], ex.StackTrace, ex.Source, ex.Message,LLID.Split('*')[0], DateTime.Now.ToString());   
    		   BOTErrorLog(LLID.Split('*')[1], ex.StackTrace, ex.Source, ex.Message,LLID.Split('*')[0], DateTime.Now.ToString());
            }
    
            public static void BotExceptionNotification(string Environment, string exceptionStack, string exceptionSource,
                string fullException, string loggedInUser, string exceptionDateTime)
            {
              // Send email code goes here using above peramaeters in you html
            }
          
        }
    }
