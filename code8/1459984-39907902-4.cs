    public class SwashbuckleOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            try
            {
                var pathSegments = context.ApiDescription.RelativePath.Split(new[] { '/' }).ToList();
                var version = string.Empty;
                var controller = string.Empty;
                if (pathSegments.Count > 1)
                {
                    version = pathSegments[0];
                    controller = pathSegments[1] + "_";
                    pathSegments = pathSegments.Skip(2).Where(x => !x.Contains("{")).ToList();
                }
                string httpMethod = FirstCharToUpper(context.ApiDescription.HttpMethod);
                var routeName = context.ApiDescription.ActionDescriptor?.AttributeRouteInfo?.Name ?? string.Empty;
                operation.OperationId = $"{version}{controller}{httpMethod}{string.Join("", pathSegments)}{routeName}";
            }
            catch (Exception ex)
            {
                throw new Exception("Are you missing the [Route(\"v1/[controller]/\")] on your Controller?", ex);
            }
        }
        private string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                return string.Empty;
            input = input.Trim().ToLower();
            return input.First().ToString().ToUpper() + new string(input.Skip(1).ToArray());
        }
    }
