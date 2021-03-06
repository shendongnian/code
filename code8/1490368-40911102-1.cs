    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq.Expressions;
    
    namespace TestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            class propertyclass2
            {
                public propertyclass2()
                {
    
                }
            }
    
            class propertyclass1
            {
                public propertyclass1()
                {
    
                }
    
                public propertyclass2 STUFF { get; set; }
            }
    
            class mainclass
            {
                public mainclass()
                {
    
                }
    
                public propertyclass1 DATA { get; set; }
            }
    
            // returning property as lambda from string
            public static Func<T, object> GetPropertyFunc<T>(string property)
            {
                try
                {
                    var parameter = Expression.Parameter(typeof(T), "obj");
    
                    Expression body = parameter;
                    foreach (var member in property.Split('.'))
                    {
                        // = Expression.PropertyOrField(body, member);
                        var prop = Expression.PropertyOrField(body, member);
                        body = Expression.Condition(Expression.Equal(body, Expression.Constant(null, body.Type)), Expression.Constant(null, prop.Type), prop);
                    }
    
                    // conversion from Toutput to object
                    Expression converted = Expression.Convert(body, typeof(object));
    
                    return Expression.Lambda<Func<T, object>>(converted, parameter).Compile();
    
                    //return (Func<T, object>)Expression.Lambda(body, parameter).Compile();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            [TestMethod]
            public void TestMethod1()
            {
                mainclass t = new mainclass();
                t.DATA = new propertyclass1();
    
                Func<mainclass, object> ex = GetPropertyFunc<mainclass>("DATA.STUFF");
                object val = ex(t);
    
                Assert.AreEqual(val, null);
            }
    
            [TestMethod]
            public void TestMethod2()
            {
                mainclass t = new mainclass();
    
                Func<mainclass, object> ex = GetPropertyFunc<mainclass>("DATA.STUFF");
                object val = ex(t);
    
                Assert.AreEqual(val, null);
            }
    
            [TestMethod]
            public void TestMethod3()
            {
                mainclass t = new mainclass();
                t.DATA = new propertyclass1();
                t.DATA.STUFF = new propertyclass2();
    
                Func<mainclass, object> ex = GetPropertyFunc<mainclass>("DATA.STUFF");
                object val = ex(t);
    
                Assert.AreNotEqual(val, null);
            }
        }
    }
    
