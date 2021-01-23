    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    namespace MwoCWDropDeckBuilder.Infrastructure.Interfaces
    {
        public interface IValidatingBaseViewModel : IDataErrorInfo
        {
            bool IsValid();
            bool IsValid<T>(Expression<Func<T>> propertyExpression);
        }
    }
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using MwoCWDropDeckBuilder.Infrastructure.Interfaces;
    namespace MwoCWDropDeckBuilder.Infrastructure
    {
        public class ValidatingBaseViewModel<TModelType> : ValidatingBaseViewModel, IBaseViewModel<TModelType>
            where TModelType : class
        {
            public TModelType Model { get; private set; }
            public ValidatingBaseViewModel(TModelType modelObject)
            {
                Model = modelObject;
            }
        }
        public class ValidatingBaseViewModel : BaseViewModel, IValidatingBaseViewModel
        {
            private Dictionary<string, bool> _validationResults = new Dictionary<string, bool>();
            public string Error
            {
                get { return null; }
            }
            public string this[string propertyName]
            {
                get { return OnValidate(propertyName); }
            }
            public bool IsValid()
            {
                var t = GetType();
                var props = t.GetProperties().Where(
                    prop => Attribute.IsDefined(prop, typeof(ValidationAttribute)));
                return props.All(x => IsValid(x.Name));
            }
            public bool IsValid<T>(Expression<Func<T>> propertyExpression)
            {
                var propertyName = GetPropertyName(propertyExpression);
                return IsValid(propertyName);
            }
            private bool IsValid(string propertyName)
            {
                OnValidate(propertyName);
                return _validationResults[propertyName];
            }
            private string OnValidate(string propertyName)
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ArgumentException("Invalid property name", propertyName);
                }
                string error = string.Empty;
                var value = GetValue(propertyName);
                var t = GetType();
                var props = t.GetProperties().Where(
                    prop => Attribute.IsDefined(prop, typeof(ValidationAttribute)));
                if (props.Any(x => x.Name == propertyName))
                {
                    var results = new List<ValidationResult>(1);
                    var result = Validator.TryValidateProperty(
                        value,
                        new ValidationContext(this, null, null)
                        {
                            MemberName = propertyName
                        },
                        results);
                    StoreValidationResult(propertyName, result);
                    if (!result)
                    {
                        var validationResult = results.First();
                        error = validationResult.ErrorMessage;
                    }
                }
                return error;
            }
            private void StoreValidationResult(string propertyName, bool result)
            {
                if (_validationResults.ContainsKey(propertyName) == false)
                    _validationResults.Add(propertyName, false);
                _validationResults[propertyName] = result;
            }
            #region Privates
            private string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
            {
                var memberExpression = propertyExpression.Body as MemberExpression;
                if (memberExpression == null)
                {
                    throw new InvalidOperationException();
                }
                return memberExpression.Member.Name;
            }
            private object GetValue(string propertyName)
            {
                object value;
                var propertyDescriptor = TypeDescriptor.GetProperties(GetType()).Find(propertyName, false);
                if (propertyDescriptor == null)
                {
                    throw new ArgumentException("Invalid property name", propertyName);
                }
                value = propertyDescriptor.GetValue(this);
                return value;
            }
            #endregion
        }
    }
