var testTupleList = new List<(double, double)>() {
    (1.333,122.3),
    (2.343,142.3)
};
List<double[]> result =testTupleList.Select(data => data.ToTuple()
   .GetType()
   .GetProperties()
   .Select(property => property.GetValue(data.ToTuple()))
   .Cast<double>()
   .ToArray()).ToList();
