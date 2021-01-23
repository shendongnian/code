    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using NHibernate;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;
    
    namespace Postal
    {
        public class MyChar:IUserType
        {
    
            public bool IsMutable
            {
                get { return false; }
            }
            public Type ReturnedType
            {
                get { return typeof(string); }
            }
    
            public SqlType[] SqlTypes
            {
                get { return new SqlType[1] { new SqlType(DbType.AnsiStringFixedLength) }; }
            }
    
            public object Assemble(object cached, object owner)
            {
                return this.DeepCopy(cached);
            }
    
            public object DeepCopy(object value)
            {
                if (value == null)
                {
                    return (object)null;
                }
                else
                {
                    return (object)string.Copy((string)value);
                }
            }
    
            public object Disassemble(object value)
            {
                return this.DeepCopy(value);
            }
    
            public bool Equals(object x, object y)
            {
                if (x == null)
                {
                    return y == null;
                }
                else
                {
                    return x.Equals(y);
                }
            }
    
            public int GetHashCode(object x)
            {
                return x.GetHashCode();
            }
    
            public object NullSafeGet(IDataReader rs, string[] names, object owner)
            {
                string str = (string)NHibernateUtil.String.NullSafeGet(rs, names[0]);
                return str != null ? (object)str.Trim() : (object)(string)null;
            }
    
            public void NullSafeSet(IDbCommand cmd, object value, int index)
            {
                if (value == null)
                {
                    NHibernateUtil.String.NullSafeSet(cmd, (object)null, index);
                }
                else
                {
                    value = (object)((string)value).Trim();
                    NHibernateUtil.String.NullSafeSet(cmd, value, index);
                }
            }
    
            public object Replace(object original, object target, object owner)
            {
                return original;
            }
        }
    }
