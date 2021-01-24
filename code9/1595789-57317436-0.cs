        public static void ResetConcurrencyValues(this DbContext context, Object entity) {
            var lEntry = context.Entry(entity);
            foreach (var lProperty in lEntry.Metadata.GetProperties().Where(x => x.IsConcurrencyToken)) {
                lEntry.OriginalValues[lProperty] = lEntry.CurrentValues[lProperty];
            }
        }
