    public static class ModelStateExtensions
    {
        public static IEnumerable<ModelStateSummary> ToSummary(this ModelStateDictionary modelState)
        {
            return modelState.Select(state => new ModelStateSummary
            {
                PropertyName = state.Key,
                ErrorMessages = state.Value.Errors.Select(x => x.ErrorMessage).ToArray()
            });
        }
        public static ModelStateDictionary ToModelState(this IEnumerable<ModelStateSummary> summary)
        {
            var modelStates = new ModelStateDictionary();
            foreach (var modelState in summary)
            {
                var data = new ModelState();
                foreach (var errorMessage in modelState.ErrorMessages)
                {
                    data.Errors.Add(new ModelError(errorMessage));
                }
                modelStates.Add(modelState.PropertyName, data);
            }
            return modelStates;
        }
    }
