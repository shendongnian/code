	[Validator(typeof(ParentClassValidator))]
	public class ParentClass
	{
		public int ParentId { get; set; }
		public int ActivityId { get; set; }
		public DateTime UpateDate { get; set; }
		public IList<ChildClass> ChildList { get; set; }
	}
	public class ParentClassValidator : AbstractValidator<ParentClass>
	{
		public ParentClassValidator()
		{
			RuleFor(x => x.ParentId).NotEmpty().WithMessage("Parent Id cannot be empty");
			When(x => x.ParentId == 1, () =>
			{
				  RuleFor(x => x.ActivityId).NotEmpty().WithMessage("Activity To cannot be empty.");
			});
		}
		
		public override ValidationResult Validate(ValidationContext<ParentClass> context)
		{
			RuleFor(x => x.ChildList).SetCollectionValidator(new ExtMobileTransactionDataValidator(context.InstanceToValidate));
			return base.Validate(context);
		}
	}
	public class ChildClass
	{
		public int ChildId { get; set; }
		public DateTime DueDate { get; set; }
	}
	public class ChildClassValidator : AbstractValidator<ChildClass>
	{
		public ChildClassValidator(ParentClass parent)
		{
			RuleFor(x => x.ChildId).NotEmpty().WithMessage("Child Id cannot be empty");
			if(parent.ParentId == 1)
			{
				RuleFor(x => x.DueDate).Must(date => date != default(DateTime)).WithMessage("Due date cannot be empty");
			}
		}
	}
