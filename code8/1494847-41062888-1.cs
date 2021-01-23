    public static class ExceptionHelper
    {
        private static Exception GetInnermostException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        public static bool IsUniqueConstraintViolation(Exception ex)
        {
            var innermost = GetInnermostException(ex);
            var sqlException = innermost as SqlException;
            return sqlException != null && sqlException.Class == 14 && (sqlException.Number == 2601 || sqlException.Number == 2627);
        }
    }
 
