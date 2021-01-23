    class AnnotatedVal {
        public string Val {get;}
        public string Annotation {get;}
        public AnnotatedVal(string val, string annotation) {
            // Do null checking
            Val = val;
            Annotation = annotation;
        }
        public bool Equals(object obj) {
            var other = obj as AnnotatedVal;
            return other != null && other.Val == Val && other.Annotation == Annotation;
        }
        public int GetHashCode() {
            return 31*Val.GetHashCode() + Annotation.GetHashCode();
        }
    }
    private Dictionary<AnnotatedVal,Dictionary<AnnotatedVal,AnnotatedVal>> ActionCollection;
