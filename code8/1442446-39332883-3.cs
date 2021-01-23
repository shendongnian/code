    using LambdaSample.Interfaces;
    namespace LambdaSample.Framework
    {
        /// <summary>
        /// Item for range predicates (e.g. "1-5")
        /// </summary>
        public class PredicateItemRange : IPredicateItem
        {
            public PredicateItemRange()
            {
            }
            public bool IsValid => Value1 != null && Value2 != null;
            public object Value1 { get; set; }
            public object Value2 { get; set; }
        }
    }
