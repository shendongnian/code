    public class MultiFact : FactAttribute
    {
        public MultiFact(params Type[] types)
        {
            var result = types.Select(Activator.CreateInstance).Cast<FactAttribute>().ToList();
            if (result.Any(it => Text.IsNotBlank(it.Skip)))
            {
                Skip = string.Join(", ", result.Where(it => Text.IsNotBlank(it.Skip)).Select(it => it.Skip));
            }
        }
    }
