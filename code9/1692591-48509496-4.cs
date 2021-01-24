    var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "anId", "anotherId" };
    var values = new List<List<string>>() {
        new List<string> { "10", "20" },
        new List<string> { "50", "60" }
    };
            
    var query = _unitOfWork.ParentRepository.Queryable().Include("ParentField.Field");
    query = query.Where(i =>
        (
            names.All(n => i.ParentField.Any(pField => pField.Name.Equals(n, StringComparison.OrdinalIgnoreCase))) &&
            values.All(l => l.Any(v => i.ParentField.Any(pField => pField.Value.Equals(v, StringComparison.OrdinalIgnoreCase))))
        ));
