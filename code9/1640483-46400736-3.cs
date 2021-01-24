    using System;
    using System.Collections;
    using System.Collections.Generic;
    public interface IStringList : IList<string>, IList 
    { 
        new int Count { get; }
        new string this[int index] { get; set; }
    }
