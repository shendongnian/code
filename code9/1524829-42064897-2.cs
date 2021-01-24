    public interface ISpecialCaseRequestValidation: IValidation
    {
    }
    public interface IValidation
    {
        bool IsValid(SpecialCaseRequest specialCase, out Error error);
    }
