    //using Microsoft.AspNetCore.Mvc.Formatters;
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type type)
        {
            return true; // you could be fancy here but this gets the job done.
        }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            
            // your magic goes here
            string foo = "Hello World!";
            return response.WriteAsync(foo);
        }
    }
