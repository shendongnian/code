    namespace MyNamespace
    {
	    public class NHibTuple<T1, T2> : ICompositeUserType
    	{
			public bool IsMutable { get { return false; } }
			public string[] PropertyNames { get { return new[] { "Item1", "Item2" }; } }
			public IType[] PropertyTypes { get { return new[] { GetNHibernateType<T1>(), GetNHibernateType<T2>() }; } }
			public Type ReturnedClass { get { return typeof(Tuple<T1, T2>); } }
			public object Assemble(object cached, ISessionImplementor session, object owner)
			{
				return DeepCopy(cached);
			}
			public object DeepCopy(object value)
			{
				var tuple = (Tuple<T1, T2>)value;
				return Tuple.Create(tuple.Item1, tuple.Item2);
			}
			public object Disassemble(object value, ISessionImplementor session)
			{
				return DeepCopy(value);
			}
			public new bool Equals(object x, object y)
			{
				if (ReferenceEquals(x, y))
					return true;
				if (x == null || y == null)
					return false;
				return x.Equals(y);
			}
			public int GetHashCode(object x)
			{
				return x == null ? 0 : x.GetHashCode();
			}
			public object GetPropertyValue(object component, int property)
			{
				var tuple = (Tuple<T1, T2>)component;
				switch (property) {
					case 0:
						return tuple.Item1;
					case 1:
						return tuple.Item2;
					default:
						throw new InvalidOperationException(String.Format("No property number {0} found", property));
				}
			}
			public void SetPropertyValue(object component, int property, object value)
			{
				throw new InvalidOperationException("Immutable, SetPropertyValue is not allowed");
			}
			public object NullSafeGet(IDataReader dr, string[] names, ISessionImplementor session, object owner)
			{
				var item1 = (T1)PropertyTypes[0].NullSafeGet(dr, names[0], session, owner);
				var item2 = (T2)PropertyTypes[1].NullSafeGet(dr, names[1], session, owner);
				return Tuple.Create(item1, item2);
			}
			public void NullSafeSet(IDbCommand cmd, object value, int index, bool[] settable, ISessionImplementor session)
			{
				if (value == null) {
					NHibernateUtil.Timestamp.NullSafeSet(cmd, null, index);
					NHibernateUtil.TimeSpan.NullSafeSet(cmd, null, index + 1);
				} else {
					var tuple = (Tuple<T1, T2>)value;
					PropertyTypes[0].NullSafeSet(cmd, tuple.Item1, index, session);
					PropertyTypes[1].NullSafeSet(cmd, tuple.Item2, index + 1, session);
				}
			}
			public object Replace(object original, object target, ISessionImplementor session, object owner)
			{
				return DeepCopy(original);
			}
			static IType GetNHibernateType<TYPE>()
			{
				// No default constructor on String, so...
				if (typeof(TYPE) == typeof(String))
					return NHibernateUtil.String;
				var inst = Activator.CreateInstance<TYPE>();
				return NHibernateUtil.GuessType(inst);
			}
		}
	}
