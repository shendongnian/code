        [InjectLambda]
        public static bool To<T>(this AdvancedDeductionAbstractVM value) where T : AdvancedDeductionAbstractVM, new()
        {
            throw new NotImplementedException();
        }
        
        public static Expression<Func<AdvancedDeductionAbstractVM,T>> To<T>() where T : AdvancedDeductionAbstractVM, new()
        {
            return i =>
                new T()
                {
                    ID = i.ID,
                    Amount = i.Amount,
                    DateTime = i.DateTime,
                    Description = i.Description,
                    DriverName = i.Driver.Name
                };
        }
