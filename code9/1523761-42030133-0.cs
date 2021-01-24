    using System;
    using System.Reflection;
    using FluentValidation;
    using StructureMap;
    
    namespace Business.Managers.Interfaces
    {
        public class FluentValidatorFactory : IValidatorFactory
        {
            private readonly IContainer _container;
    
            public FluentValidatorFactory(IContainer container)
            {
                _container = container;
            }
            public IValidator<T> GetValidator<T>()
            {
                return (IValidator<T>)GetValidator(typeof(T));
            }
    
            public IValidator GetValidator(Type type)
            {
                IValidator validator;
    
                try
                {
                    validator = CreateInstance(typeof(IValidator<>).MakeGenericType(type));
                }
                catch (Exception)
                {
                    // Get base type and try to find validator for base type (used for polymorphic classes)
                    var baseType = type.GetTypeInfo().BaseType;
                    if (baseType == null)
                    {
                        throw;
                    }
    
                    validator = CreateInstance(typeof(IValidator<>).MakeGenericType(baseType));
                }
    
                return validator;
            }
    
            public IValidator CreateInstance(Type validatorType)
            {
                return _container.GetInstance(validatorType) as IValidator;
            }
        }
    }
