    static class QueryableExtensions {
        public static IQueryable<T> WithComment<T>(this IQueryable<T> query, string comment) {
            EFCommentInterceptor.SetComment(comment);
            return query;
        }
    }
