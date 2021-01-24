    using System.Collections.Generic;
    namespace DL.SO.MessageEnum.Web.UI.Models
    {
        public class EnumMeta
        {
            public int EnumId { get; set; }
            public bool IsFlag { get; set; }
            public List<MessageEnum> MessageMetas { get; set; }
        }
    }
