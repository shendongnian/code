        private static readonly MethodInfo _miAnyWhere = ((MethodCallExpression)((Expression<Func<IEnumerable<DocumentField>, bool>>)(fields => fields.Any(f => false))).Body).Method;
        private static readonly Expression<Func<Document, IEnumerable<DocumentField>>> _fieldsAccessor = doc => doc.Fields;
        /// <summary>
        /// <paramref name="documents"/>.Where(doc => doc.Fields.Any(<paramref name="fieldPredicates"/>[0]) && ... )
        /// </summary>
        public static IQueryable<Document> HavingAllFields(this IQueryable<Document> documents, IEnumerable<Expression<Func<DocumentField, bool>>> fieldPredicates)
        {
            using (var e = fieldPredicates.GetEnumerator())
            {
                if (!e.MoveNext()) return documents;
                Expression predicateBody = Expression.Call(_miAnyWhere, _fieldsAccessor.Body, e.Current);
                while (e.MoveNext())
                    predicateBody = Expression.AndAlso(predicateBody, Expression.Call(_miAnyWhere, _fieldsAccessor.Body, e.Current));
                var predicate = Expression.Lambda<Func<Document, bool>>(predicateBody, _fieldsAccessor.Parameters);
                return documents.Where(predicate);
            }
        }
