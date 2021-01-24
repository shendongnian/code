    public abstract class Client
    {
        public abstract void LoginRedirect(ILoginView view);
    }
    public class Customer : Client
    {
        public void LoginRedirect(ILoginView view)
        {
            view.RedirectToCustomerHomePage();
        }
    }
