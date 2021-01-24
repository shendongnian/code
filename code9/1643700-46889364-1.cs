    public class SaveProxyCommandValidator : AbstractValidator<SaveProxyCommand>{
        
        public SaveProxyCommandValidator()
        {
            RuleFor(o => o).MustAsync(CheckIdNumberAlreadyExists)
                           .WithName("Id")
                           .WithState(o => new ValidationFailure(nameof(o.IdNumber), "Id Number Already Exist"));
        }
        private static async Task<bool> CheckIdNumberAlreadyExists(SaveProxyCommand command) {
            if (command.Id > 0)
                return true;
            var existingIdNumbers = new[] {
                1, 2, 3, 4
            };
            // This is a fudge, but you'd make your db call here
            var isNewNumber = !(await Task.FromResult(existingIdNumbers.Contains(command.IdNumber)));
            return isNewNumber;
        }
    }
