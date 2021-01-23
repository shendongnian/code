    public class YourCustomType
    {
        public string Name {get; set;}
        public var WhateverElse { get; set; }
    }
    @foreach(YourCustomType item in model.YourList)
    {
         //item.Name
         //item.WhateverElse
    }
