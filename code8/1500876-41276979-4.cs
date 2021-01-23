    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using ReactiveUI;
    
    namespace Weingartner.Lens
    {
        /// <summary>
        /// An object you can add properties to at runtime which raises INPC events when those
        /// properties are changed.
        /// </summary>
        [DataContract]
        public class DynamicNotifyingObject : ReactiveObject, IDynamicMetaObjectProvider
        {
            #region Private Members
    
            [DataMember]
            private Dictionary<string, object> _DynamicProperties;
            [DataMember]
            private Dictionary<string, Type> _DynamicPropertyTypes;
    
            #endregion Private Members
    
            #region Constructor
    
            public DynamicNotifyingObject() : this(new Tuple<string,Type>[] { }) { }
    
            public DynamicNotifyingObject(IEnumerable<Tuple<string,Type>> propertyNames)
            {
                if (propertyNames == null)
                {
                    throw new Exception("propertyNames is empty");
                }
    
                _DynamicProperties = new Dictionary<string, object>();
                _DynamicPropertyTypes = new Dictionary<string, Type>();
                foreach ( var prop in propertyNames )
                {
                    AddProperty(prop.Item1, prop.Item2);
                }
            }
            #endregion Constructor
    
            public void AddProperty<T>( string propertyName, T initialValue )
            {
                _DynamicProperties.Add(propertyName, initialValue);
                _DynamicPropertyTypes.Add(propertyName, typeof(T));
                this.RaisePropertyChanged(propertyName);
            }
    
            /// <summary>
            /// Set the property. Will throw an exception if the property does not exist. 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="propertyName"></param>
            /// <param name="raw"></param>
            public void SetPropertyValue<T>(string propertyName, T raw)
            {
                if (!_DynamicProperties.ContainsKey(propertyName))
                {
                    throw new ArgumentException(propertyName + " property does not exist on " + GetType().Name);
                }
    
                var converter = DynamicLens2INPC.CreateConverter<T>(raw.GetType(), _DynamicPropertyTypes[propertyName]);
                var value = converter(raw);
    
                if (!value.Equals(_DynamicProperties[propertyName]))
                {
                    this.RaisePropertyChanging(propertyName);
                    _DynamicProperties[propertyName] = (object) value;
                    this.RaisePropertyChanged(propertyName);
                }
            }
            /// <summary>
            /// Get the property. Will throw an exception if the property does not exist.
            /// </summary>
            /// <param name="propertyName"></param>
            /// <returns></returns>
            public object GetPropertyValue(string propertyName)
            {
                if (!_DynamicProperties.ContainsKey(propertyName))
                {
                    throw new ArgumentException(propertyName + " property does not exist " + GetType().Name);
                }
                return _DynamicProperties.ContainsKey(propertyName) ? _DynamicProperties[propertyName] : null;
            }
    
            public bool HasDynamicProperty(string propertyName) => _DynamicProperties.ContainsKey(propertyName);
    
            DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression e) { return new MetaObject(e, this); }
    
            /// <summary>
            /// Support for MetaObject. See https://github.com/remi/MetaObject 
            /// </summary>
            /// <param name="binder"></param>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (HasDynamicProperty(binder.Name))
                {
                    result = GetPropertyValue(binder.Name);
                    return true;
                }
    
                // This path will return any real properties on the object
                result = null;
                return false;
            }
    
            /// <summary>
            /// Support for MetaObject. See https://github.com/remi/MetaObject
            /// </summary>
            /// <param name="binder"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public bool TrySetMember(SetMemberBinder binder, object value)
            {
                if (HasDynamicProperty(binder.Name))
                {
                    SetPropertyValue(binder.Name, value);
                    return true;
                }
    
                // This path will try to set any real properties on the object
                return false;
            }
    
        }
    }
