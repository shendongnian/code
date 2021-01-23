    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    
    namespace Potato
    {
        public class MailgunEmail
        {
            public IEnumerable<IFormFile> Attachments { get; set; }
    
            public string Recipient { get; set; }
            public string Sender { get; set; }
            public string From { get; set; }
            public string Subject { get; set; }
            public string BodyPlain { get; set; }
            public string StrippedText { get; set; }
            public string StrippedSignature { get; set; }
            public string BodyHtml { get; set; }
            public string StrippedHtml { get; set; }
            public int? AttachmentCount { get; set; }
            public int Timestamp { get; set; }
            public string Token { get; set; }
            public string Signature { get; set; }
            public string MessageHeaders { get; set; }
            public string ContentIdMap { get; set; }
    
            public MailgunEmail(HttpRequest request)
            {
                var form = request.Form;
    
                Attachments = new List<IFormFile>(form.Files);
    
                foreach (var prop in typeof(MailgunEmail).GetProperties()) {
                    string propName = Dashify(prop.Name);
                    var curVal = form[propName];
                    if (curVal.Count > 0) {
                        prop.SetValue(this, To(curVal[0], prop.PropertyType), null);
                    }
                }
            }
    
            private object To(IConvertible obj, Type t)
            {
                Type u = Nullable.GetUnderlyingType(t);
    
                if (u != null) {
                    return (obj == null) ? GetDefaultValue(t) : Convert.ChangeType(obj, u);
                } else {
                    return Convert.ChangeType(obj, t);
                }
            }
    
            private object GetDefaultValue(Type t)
            {
                if (t.GetTypeInfo().IsValueType) {
                    return Activator.CreateInstance(t);
                }
                return null;
            }
    
            private string Dashify(string source)
            {
                string result = "";
                var chars = source.ToCharArray();
                for (int i = 0; i < chars.Length; ++i) {
                    var c = chars[i];
                    if (i > 0 && char.IsUpper(c)) {
                        result += '-';
                    }
                    result += char.ToLower(c);
                }
                return result;
            }
        }
    }
