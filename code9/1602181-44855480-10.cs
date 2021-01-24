    <%@ WebHandler Language="C#" Class="LongRunningTask" %>
    
    using System;
    using System.Web;
    using System.Web.SessionState;
    using System.Web.Script.Serialization;
    using System.Threading.Tasks;
    public class LongRunningTask : IHttpHandler, IRequiresSessionState
    {
        private const string INVALID = "Invalid value for m";
        private const string SESSIONKEY = "LongRunningTask";
        private const string STARTED = "Task Started";
        private const string RUNNING = "Task Running";
        private const string COMPLETED = "Task Completed";
    
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            string m = request.QueryString["m"];
            switch (m)
            {
                case "start":
                    TaskRunner runner = new TaskRunner();
                    context.Session[SESSIONKEY] = runner.DoWork();
                    ShowResponse(context, STARTED);
                    break;
                case "progress":
                    Task<int> t = (Task<int>)context.Session[SESSIONKEY];
                    ShowResponse(context, t.IsCompleted ? COMPLETED : RUNNING);
                    return;
                default:
                    ShowResponse(context, INVALID);
                    break;
            }
        }
    
        private void ShowResponse(HttpContext context, string message)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string json = ser.Serialize(message);
            context.Response.ContentType = "text/javascript";
            context.Response.Write(json);
        }
    
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private class TaskRunner
        {
            public bool Finished { get; set; }
            private Task<int> longTask;
            public TaskRunner()
            {
    
            }
            public Task<int> DoWork()
            {
                var tcs = new TaskCompletionSource<int>();
                Task.Run(async () =>
                {
                    // instead of the following line, launch you method here.
                    await Task.Delay(1000 * 60 * 1);
                    tcs.SetResult(1);
                });
                longTask = tcs.Task;
                return longTask;
            }
        }
    
    }
