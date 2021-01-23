    public class EncryptionMiddleware : OwinMiddleware
    {
        public EncryptionMiddleware(OwinMiddleware next) : base(next)
        {
            //
        }
        public async override Task Invoke(IOwinContext context)
        {
            var request = context.Request;
            string requestBody = new StreamReader(request.Body).ReadToEnd();
            var obj = // do your work here
            System.Web.HttpContext.Current.Items[OBJECT_ITEM_KEY] = obj;
            await Next.Invoke(context);
            return;
        }
    }
