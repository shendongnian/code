    public interface ICommonResource
    {
        string ErrorUnexpectedNumberOfRowsSaved { get; }
        string ErrorNoRecordsSaved { get; }
        string ErrorConcurrency { get; }
        string ErrorGeneric { get; }
        string RuleAlreadyInUse { get; }
        string RuleDoesNotExist { get; }
        string RuleInvalid { get; }
        string RuleMaxLength { get; }
        string RuleRequired { get; }
    }
    public class CommonResource : ICommonResource
    {
        private readonly IStringLocalizer<CommonResource> _localizer;
        public CommonResource(IStringLocalizer<CommonResource> localizer) =>
            _localizer = localizer;
        
        public string ErrorUnexpectedNumberOfRowsSaved => GetString(nameof(ErrorUnexpectedNumberOfRowsSaved));
        public string ErrorNoRecordsSaved => GetString(nameof(ErrorNoRecordsSaved));
        public string ErrorConcurrency => GetString(nameof(ErrorConcurrency));
        public string ErrorGeneric => GetString(nameof(ErrorGeneric));
        public string RuleAlreadyInUse => GetString(nameof(RuleAlreadyInUse));
        public string RuleDoesNotExist => GetString(nameof(RuleDoesNotExist));
        public string RuleInvalid => GetString(nameof(RuleInvalid));
        public string RuleMaxLength => GetString(nameof(RuleMaxLength));
        public string RuleRequired => GetString(nameof(RuleRequired));
        private string GetString(string name) =>
            _localizer[name];
    }
