    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    namespace SampleArticle
    {
        public class MyWebContentTypeMapper : WebContentTypeMapper
        {
            public override WebContentFormat GetMessageFormatForContentType(string contentType)
            {
    
                return WebContentFormat.Raw;
            }
        }
    }
