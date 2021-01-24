    public class WebApiTracer : ITraceWriter
    {
        public void Trace(HttpRequestMessage request, string category, System.Web.Http.Tracing.TraceLevel level, Action<TraceRecord> traceAction)
        {
            TraceRecord rec = new TraceRecord(request, category, level);
            traceAction(rec);
            WriteTrace(rec);
        }
        protected void WriteTrace(TraceRecord rec)
        {
            var message = string.Format("WebApi. {0};{1};{2};{3};{4}",
                rec.Category, rec.Operator, rec.Operation, rec.Message, rec.Exception);
            myLog.Write(message);
        }
    }
