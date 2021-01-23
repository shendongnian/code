    using System;
    using System.Collections.Generic;
    namespace LambdaSample.Interfaces
    {
        // Used to defined IPredicateParser for parsing predicates
        public interface IPredicateParser
        {
            bool Parse(string text, bool rangesAllowed, Type definedType);
            List<IPredicateItem> Items { get; }
        }
    }
