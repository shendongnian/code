    class TaskComparer : IEqualityComparer<Task> {
        public bool Equals(Task x, Task y) {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.Name, y.Name) && string.Equals(x.ResourceName, y.ResourceName);
        }
        public int GetHashCode(Task task) {
            unchecked {
                return 
                    ((task?.Name?.GetHashCode()         ?? 0) * 397) ^ 
                     (task?.ResourceName?.GetHashCode() ?? 0);
            }
        }
    }
