    public static class CustomAssert
    {
        public static void DoesNotThrow<T>(TestDelegate code) where T : Exception
        {
            DoesNotThrow<T>(code, string.Empty, null);
        }
        public static void DoesNotThrow<T>(TestDelegate code, string message, params object[] args) where T : Exception
        {
            Assert.That(code, new ThrowsNotExceptionConstraint<T>(), message, args);
        }
    }
    
    public class ThrowsNotExceptionConstraint<T> : ThrowsExceptionConstraint where T : Exception
    {
        public override string Description
        {
            get { return string.Format("throw not exception {0}", typeof(T).Name); }
        }
        
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            var result = base.ApplyTo<TActual>(actual);
            
            return new ThrowsNotExceptionConstraintResult<T>(this, result.ActualValue as Exception);
        }
        
        protected override object GetTestObject<TActual>(ActualValueDelegate<TActual> del)
        {
            return new TestDelegate(() => del());
        }
        
        class ThrowsNotExceptionConstraintResult<T> : ConstraintResult where T : Exception
        {
            public ThrowsNotExceptionConstraintResult(ThrowsNotExceptionConstraint<T> constraint, Exception caughtException)
                : base(constraint, caughtException, !(caughtException is T)) { }
            public override void WriteActualValueTo(MessageWriter writer)
            {
                if (this.Status == ConstraintStatus.Failure)
                    writer.Write("throws exception {0}", typeof(T).Name);
                else
                    base.WriteActualValueTo(writer);
            }
        }
    }
