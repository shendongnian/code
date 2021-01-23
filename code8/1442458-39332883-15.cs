    using LambdaSample.Interfaces;
    namespace LambdaSample.Framework
    {
        /// <summary>
        /// Item for single predicate (e.g. "44")
        /// </summary>
        public class PredicateItemSingle : IPredicateItem
        {
            public PredicateItemSingle()
            {
            }
            public bool IsValid => Value != null;
            public object Value { get; set; }
        }
    }
