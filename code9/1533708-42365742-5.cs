    public class ServicerRequestViewModelValidator : AbstractValidator<ServiceRequestViewModel>
    {
             public ServiceRequestViewModelValidator(ILocalizationService localizationService)
                {
                       RuleFor(x => x.IdStato).NotNull().WithMessage(()=>string.Format(localizationService.GetMessage("Validation.General.MandataryField"), localizationService.GetMessage("ServiceRequestDetail.State")));
                }
            }
