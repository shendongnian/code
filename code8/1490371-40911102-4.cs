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
            class TestRefType2
            {
                public TestRefType2()
                {
    
                }
            }
    
            class TestRefType1
            {
                public TestRefType1()
                {
    
                }
    
                public Guid VALUETYPE { get; set; }
                public TestRefType2 REFTYPE { get; set; }
            }
    
            class MainType
            {
                public MainType()
                {
    
                }
    
                public TestRefType1 REFTYPE { get; set; }
            }
    
            public static object GetDefault(Type type)
            {
                if (type.IsValueType)
                {
                    return Activator.CreateInstance(type);
                }
                return null;
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
                        var prop = Expression.PropertyOrField(body, member);
                        body = Expression.Condition(Expression.Equal(body, Expression.Default(body.Type)), Expression.Default(prop.Type), prop);
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
                MainType t = new MainType();
                t.REFTYPE = new TestRefType1();
    
                Func<MainType, object> ex = GetPropertyFunc<MainType>("REFTYPE.VALUETYPE");
                object val = ex(t);
    
                Assert.AreEqual(default(Guid), val);
            }
    
            [TestMethod]
            public void TestMethod2()
            {
                MainType t = new MainType();
    
                Func<MainType, object> ex = GetPropertyFunc<MainType>("REFTYPE.VALUETYPE");
                object val = ex(t);
    
                Assert.AreEqual(default(Guid), val);
            }
    
            [TestMethod]
            public void TestMethod3()
            {
                MainType t = new MainType();
                t.REFTYPE = new TestRefType1();
                var guid = Guid.NewGuid();
                t.REFTYPE.VALUETYPE = guid;
    
                Func<MainType, object> ex = GetPropertyFunc<MainType>("REFTYPE.VALUETYPE");
                object val = ex(t);
    
                Assert.AreEqual(guid, val);
            }
    
            [TestMethod]
            public void TestMethod4()
            {
                MainType t = new MainType();
                t.REFTYPE = new TestRefType1();
    
                Func<MainType, object> ex = GetPropertyFunc<MainType>("REFTYPE");
                object val = ex(t);
    
                Assert.AreNotEqual(default(TestRefType1), val);
            }
    
            [TestMethod]
            public void TestMethod5()
            {
                MainType t = new MainType();
                t.REFTYPE = new TestRefType1();
    
                Func<MainType, object> ex = GetPropertyFunc<MainType>("REFTYPE.REFTYPE");
                object val = ex(t);
    
                Assert.AreEqual(default(TestRefType2), val);
            }
    
            [TestMethod]
            public void TestMethod6()
            {
                MainType t = new MainType();
    
                Func<MainType, object> ex = GetPropertyFunc<MainType>("REFTYPE.REFTYPE");
                object val = ex(t);
    
                Assert.AreEqual(default(TestRefType2), val);
            }
    
            [TestMethod]
            public void TestMethod7()
            {
                MainType t = new MainType();
                t.REFTYPE = new TestRefType1();
                var reftype2 = new TestRefType2();
                t.REFTYPE.REFTYPE = reftype2;
    
                Func<MainType, object> ex = GetPropertyFunc<MainType>("REFTYPE.REFTYPE");
                object val = ex(t);
    
                Assert.AreEqual(reftype2, val);
            }
    
        }
    }
