    public static class ProductExtensions
    {
        private static readonly ConstantExpression _zero = Expression.Constant(0); // constant 0 for no StatusFlags
        // StatusFlag : Product => Status property of Product
        private static readonly Dictionary<StatusFlags, Expression<Func<Product, int>>> _propertySelectorsByStatus = new Dictionary<StatusFlags, Expression<Func<Product, int>>>
        {
            { StatusFlags.Status1, p => p.Status1 },
            { StatusFlags.Status2, p => p.Status2 },
            { StatusFlags.Status3, p => p.Status3 },
            { StatusFlags.Status4, p => p.Status4 },
            { StatusFlags.Status5, p => p.Status5 }
        };
        /// <summary>
        /// Project a products into a result built from the product and the sum of the Product.StatusX selected by <paramref name="flags"/>.
        /// </summary>
        /// <param name="products">The source products.</param>
        /// <param name="flags">Flags selecting the specific statuses to add up.</param>
        /// <param name="resultSelector">Expression to select the result from a product and the added statuses.</param>
        public static IQueryable<TResult> Select<TResult>(this IQueryable<Product> products, StatusFlags flags, Expression<Func<Product, int, TResult>> resultSelector)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            var pProduct = resultSelector.Parameters[0];
            var pStatus = resultSelector.Parameters[1];
            var xStatusSum = _propertySelectorsByStatus
                .Where(kv => (kv.Key & flags) != 0) // flags has the specified status
                .Select(kv => new ParameterReplaceVisitor(new[] { new KeyValuePair<ParameterExpression, Expression>(kv.Value.Parameters[0], pProduct) }).Visit(kv.Value.Body)) // pProduct.StatusX
                .Aggregate((Expression)null, (sum, status) => sum == null ? status : Expression.Add(sum, status)) // pProduct.StatusX + pProduct.StatusY + ...
                ?? _zero; // fallback for StatusFlags.None
            var body = new ParameterReplaceVisitor(new[] { new KeyValuePair<ParameterExpression, Expression>(pStatus, xStatusSum) }).Visit(resultSelector.Body);
            var selector = Expression.Lambda<Func<Product, TResult>>(body, pProduct); // p => TResult
            return products.Select(selector);
        }
    }
