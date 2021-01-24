    public class SaveProxyCommandValidator : AbstractValidator<SaveProxyCommand>{
        
        public SaveProxyCommandValidator()
        {
            RuleFor(o => o.IdNumber).MustAsync(CheckIdNumberAlreadyExists)
                                    .Unless(o => o.Id > 0)
                                    .WithState(o => new ValidationFailure(nameof(o.IdNumber), "Id Number Already Exist"));
        }
        private static async Task<bool> CheckIdNumberAlreadyExists(int numberToEvaluate) {
            var existingIdNumbers = new[] {
                1, 2, 3, 4
            };
            // This is a fudge, but you'd make your db call here
            var isNewNumber = !(await Task.FromResult(existingIdNumbers.Contains(numberToEvaluate)));
            return isNewNumber;
        }
    }
