        public interface IBaseView
        {
           void Show();
           void Close();
        }
        public interface ILoginView : IBaseView
        {
           string Login { get; }
           string Password {get; }
           event EventHandler SignIn { get; }
        }
