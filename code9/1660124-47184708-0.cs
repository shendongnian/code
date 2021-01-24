        private List<string> predicateTest(Expression<Func<bool>> predicate)
        {
            var body = predicate.Body;
            var binaryExpression = body as BinaryExpression;
            var binaryBody = binaryExpression ??
                        Expression.MakeBinary(ExpressionType.Equal,
                        body, Expression.Constant(true));
            var left = binaryBody.Left;
            return Expression.Lambda(((MethodCallExpression)left).Object).Compile().DynamicInvoke() as List<string>;
        }
        [Test]
        public void PredicateTest_ShouldFindList()
        {
            List<string> list = new List<string> { "doc", "exe", "jpg" };
            var result = predicateTest(() => list.Contains("sdf"));
            Assert.That(list, Is.SameAs(result));
        }
