    public static class Extensions {
        [ContractAnnotation("null => false; notnull => true")]
        public static bool Exists(this object toCheck) {
            return toCheck != null;
        }
    }
