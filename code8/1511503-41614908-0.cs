    using System.Collections.Generic;
    namespace WebApplication1.Models
    {
        public class TipsModel
        {
            public List<string> Tips { get; }
            public TipsModel()
            {
                Tips = new List<string> {"example 1", "example 2"};
            }
        }
    }
