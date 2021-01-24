    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    public class ExceptionBodyTrackingMiddleware
    {
        public const string ExceptionRequestBodyKey = "ExceptionRequestBody";
        private readonly RequestDelegate next;
        public ExceptionBodyTrackingMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableRewind();
                await this.next.Invoke(context);
            }
            catch (Exception)
            {
                RegisterRequestBody(context);
                throw;
            }
        }
        private static void RegisterRequestBody(HttpContext context)
        {
            if (context.Request.Body?.CanSeek == false)
            {
                return;
            }
            var body = CopyStreamToString(context.Request.Body);
            context.Items[ExceptionRequestBodyKey] = body;
        }
        private static string CopyStreamToString(Stream stream)
        {
            var originalPosition = stream.Position;
            RewindStream(stream);
            string requestBody = null;
            using (var reader = new StreamReader(stream, Encoding.UTF8, true, 1024, true))
            {
                requestBody = reader.ReadToEnd();
            }
            stream.Position = originalPosition;
            return requestBody;
        }
        private static void RewindStream(Stream stream)
        {
            if (stream != null)
            {
                stream.Position = 0L;
            }
        }
    }
