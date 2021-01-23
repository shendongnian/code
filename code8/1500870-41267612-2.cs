        /// <summary>
        /// An object you can add properties to at runtime which raises INPC events when those
        /// properties are changed.
        /// </summary>
        [DataContract]
        public class DynamicNotifyingObject : ReactiveObject, IDynamicMetaObjectProvider
        {
            #region Private Members
    
            [DataMember]
            private Dictionary<string, object> _dynamicProperties;
            [DataMember]
            private Dictionary<string, Type> _dynamicPropertyTypes;
    
            [IgnoreDataMember]
            private Dyno _dynamicObject { get; set; }
    
            public Dyno DynamicObject
            {
                get
                {
                    lock (this)
                    {
                        return _dynamicObject ?? (_dynamicObject = new Dyno(this));
                    }
                }
            }
    
            #endregion Private Members
    
            #region Constructor
    
            public DynamicNotifyingObject() : this(new Tuple<string,Type>[] { }) { }
    
            public DynamicNotifyingObject(IEnumerable<Tuple<string,Type>> propertyNames)
            {
                if (propertyNames == null)
                {
                    throw new Exception("propertyNames is empty");
                }
    
                _dynamicProperties = new Dictionary<string, object>();
                _dynamicPropertyTypes = new Dictionary<string, Type>();
                foreach ( var prop in propertyNames )
                {
                    AddProperty(prop.Item1, prop.Item2);
                }
            }
            #endregion Constructor
    
            #region Public Methods
    
            public void AddProperty<T>( string propertyName, T initialValue )
            {
                _dynamicProperties.Add(propertyName, initialValue);
                _dynamicPropertyTypes.Add(propertyName, typeof(T));
                this.RaisePropertyChanged(propertyName);
    
            }
            public void AddProperty<T>( string propertyName)
            {
                AddProperty(propertyName, typeof(T));
            }
            public void AddProperty( string propertyName, Type type)
            {
                _dynamicProperties.Add(propertyName, null);
                _dynamicPropertyTypes.Add(propertyName, type);
                this.RaisePropertyChanged(propertyName);
            }
    
            public void SetPropertyValue<T>(string propertyName, T raw)
            {
                if (!_dynamicProperties.ContainsKey(propertyName))
                {
                    throw new ArgumentException(propertyName + " property does not exist on " + GetType().Name);
                }
    
                var converter = DynamicLens2INPC.CreateConverter<T>(raw.GetType(), _dynamicPropertyTypes[propertyName]);
                var value = converter(raw);
    
                if (!value.Equals(_dynamicProperties[propertyName]))
                {
                    _dynamicProperties[propertyName] = (object) value;
                    this.RaisePropertyChanged(propertyName);
                }
            }
    
            public object GetPropertyValue(string propertyName)
            {
                if (!_dynamicProperties.ContainsKey(propertyName))
                {
                    throw new ArgumentException(propertyName + " property does not exist " + GetType().Name);
                }
                return _dynamicProperties.ContainsKey(propertyName) ? _dynamicProperties[propertyName] : null;
            }
    
            #endregion Public Methods
    
    
            DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
            {
                return new ForwardingMetaObject(parameter, BindingRestrictions.Empty, this, DynamicObject,
                    // B's meta-object needs to know where to find the instance of B it is operating on.
                    // Assuming that an instance of A is passed to the 'parameter' expression
                    // we get the corresponding instance of B by reading the "B" property.
                    exprA => Expression.Property(exprA, nameof(DynamicObject))
                );
            }
    
        }
    
        public static class DynamicNotifyingObjectMixin
        {
            public static TRet RaiseAndSetIfChanged<TObj, TRet>(this TObj This, TRet newValue, ref TRet backingField, [CallerMemberName] string property = "")
                where TObj : DynamicNotifyingObject
            {
    
                if (EqualityComparer<TRet>.Default.Equals(newValue, backingField))
                {
                    return newValue;
                }
    
                This.RaisePropertyChanging(property);
                backingField = newValue;
                This.RaisePropertyChanged(property);
    
                return newValue;
            }
        }
    }
