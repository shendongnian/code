    public static class Ext
    {
        public static Constraint If(this Constraint expression, bool isTrue)
        {
            return new IfConstraint(expression, isTrue);
        }
        public class IfConstraint : Constraint
        {
            private Constraint _linkedConstraint;
            private bool _isTrue;
            public IfConstraint(Constraint linkedConstraint, bool isTrue)
            {
                _linkedConstraint = linkedConstraint;
                _isTrue = isTrue;
            }
            public override ConstraintResult ApplyTo<TActual>(TActual actual)
            {
                if (!_isTrue)
                    return new ConstraintResult(this, actual, true);
                return _linkedConstraint.ApplyTo<TActual>(actual);
            }
        }
    }
