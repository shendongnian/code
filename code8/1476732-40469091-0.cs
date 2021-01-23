        public IEnumerable<int> Search(IEnumerable<Employee> employees, IEnumerable<Condition> conditions) {
            var subresults = new List<IEnumerable<int>>();
            IEnumerable<int> result = null;
            foreach (var condition in conditions) {
                subresults.add(employees.Where(e => e.CheckCondition(condition)).Select(e => e.EmpNum));
            }
            foreach (var subresult in subresults) {
                if (result == null) {
                    result = subresult;
                } else {
                    result = result.Intersect(subresult)
                }
            }
            return result;
        }
