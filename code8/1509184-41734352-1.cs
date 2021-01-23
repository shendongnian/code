     public classs SaveCommand: IRequest<int>
     {
        public string FirstName { get; set; }
        public string Surname { get; set; }
     }
    
       public class SaveCommandValidator : AbstractValidator<SaveCommand>
        {
           public SaveCommandValidator()
           {
              RuleFor(x => x.FirstName).Length(0, 200);
              RuleFor(x => x.Surname).NotEmpty().Length(0, 200);
           }
        }
