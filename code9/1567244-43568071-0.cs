    public class InsufficientBalanceException : Exception
    {
        // Exception for when a user tries to perform a withdrawal/deposit on an account with an insufficient balance of funds.
        public InsufficientBalanceException() { }
        public InsufficientBalanceException(string message)
        : base(message) { }
        public InsufficientBalanceException(string message, Exception inner)
        : base(message, inner) { }
    }
    public class InvalidAccountException : Exception
    {
        // Exception for when a user is trying to perform an operation on an invalid account.
        public InvalidAccountException() { }
        public InvalidAccountException(string message)
        : base(message) { }
        public InvalidAccountException(string message, Exception inner)
        : base(message, inner) { }
    }
    public class InvalidNumberOfAccountsException : Exception
    {
        // Exception for when a user is trying to create an account beyond the given limit.
        public InvalidNumberOfAccountsException() { }
        public InvalidNumberOfAccountsException(string message)
        : base(message) { }
        public InvalidNumberOfAccountsException(string message, Exception inner)
        : base(message, inner) { }
    }
