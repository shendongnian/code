    public static class MagicFactory {
        public static IMagic GetMagic(bool useNoSql) {
            if (useNoSql) {
                return new NoSqlMagic();
            }
            else {
                return new SqlMagic();
            }
        }
    }
