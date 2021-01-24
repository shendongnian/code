    public class ViewDataItem
    {
        public string viewName { get; set; }
        public UpdateIndicator? updateIndicator { get; set; }
    }
    public class ViewValidator : AbstractValidator<ViewDataItem>
    {
        public ViewValidator()
        {
            RuleFor(x => x.viewName).NotEmpty().WithMessage("View name must be specified");
            RuleFor(x => x.updateIndicator).NotNull();
        }
    }
