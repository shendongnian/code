<!-- -->
    public struct InvalidParameter
    {
        [JsonPropertyName("parameter_name")]
        public string? ParameterName { get; set; }
        [JsonPropertyName("constraint_violations")]
        public string[]? ConstraintViolations { get; set; }
    }
