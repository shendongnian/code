        void FlushCookie(HttpListenerContext context, Cookie cookie)
        {
            var builder = new StringBuilder();
            builder.Append(cookie.Name);
            builder.Append("=");
            builder.Append(HttpUtility.HtmlAttributeEncode(cookie.Value));
            builder.Append(";");
            context.Response.Headers.Add(HttpResponseHeader.SetCookie, builder.ToString());
        }
