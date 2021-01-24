    [TestClass]
    public class UnitTest5 {
        [TestMethod]
        public void _MyTestMethod1() {
            var target = new ParentObject {
                ChildObject = new ChildObject {
                    ChildProperty = 5
                }
            };
            Assert.IsTrue(TestMethod1(target));
        }
        [TestMethod]
        public void _MyTestMethod2() {
            var target = new ParentObject {
                
            };
            Assert.IsFalse(TestMethod1(target));
        }
        public bool TestMethod1<T>(T ParentObject) {
            // filter is to see if ParentObject.ChildObject.ChildProperty > 1            
            // p => p.ChildObject != null && p.ChildObject.ChildProperty > 1
            // p => ...
            var param = Expression.Parameter(typeof(T));
            // p => p.ChildObject
            var childObjectExpression = Expression.PropertyOrField(param, "ChildObject");
            // p => p.ChildObject != null
            var nullExpression = Expression.NotEqual(childObjectExpression, Expression.Constant(null));
            // p => p.ChildObject.ChildProperty
            var childPropertyExpression = Expression.Property(childObjectExpression, "ChildProperty");
            // p => p.ChildObject.ChildProperty > 1
            var greaterThanExpression = Expression.MakeBinary(ExpressionType.GreaterThan, childPropertyExpression, Expression.Constant(1));
            // p => p.ChildObject != null && p.ChildObject.ChildProperty > 1
            var finalExpression = Expression.AndAlso(nullExpression, greaterThanExpression);
            var compiledExpression = Expression.Lambda<Func<T, bool>>(finalExpression, param).Compile();//Compilation will succeed
            var isTrue = compiledExpression(ParentObject);
            return isTrue;
        }
        public class ParentObject {
            public ChildObject ChildObject { get; set; }
        }
        public class ChildObject {
            public int ChildProperty { get; set; }
        }
    }
