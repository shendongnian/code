    using System;
    using System.Collections.Generic;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System.Linq;
    using System.Linq.Expressions;
    var foundItems = _collection.FindAll(x=> criteria.Any(cc=> xx.StringList.Contains(cc))).ToList();
