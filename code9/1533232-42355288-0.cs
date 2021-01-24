    /// <summary>
    /// A Comparer that's appropriate to use when wanting to match objects with expected constraints.
    /// </summary>
    /// <seealso cref="System.Collections.IComparer" />
    public class ConstraintComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            var constraint = x as IConstraint;
            var matchResult = constraint.ApplyTo(y);
            return matchResult.IsSuccess ? 0 : -1;
        }
    }
