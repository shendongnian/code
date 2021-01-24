    namespace Example.UITest
     {
     public class LoginTests : AbstractSetup
     {
        public LoginTests(Platform platform) : base(platform)
        {
            }
     
        public void Login_SuccessfullAuthentication_SuccessfullLogin()
        {
    
            //Enter Username, company name & Password
            app.EnterText(x => x.Marked("Username"), "annby");
            app.EnterText(x => x.Marked("Company name"), "sara");
            app.EnterText(x => x.Marked("Password"), "sara");
            //Tapping "Sign in" button after submitting user credentials
            app.Tap(x=>x.Text("Sign in"));
        
      }
      }
      }
     // THIS IS MY SECOND CLASS. 
    namespace Example.UITest
     {
     public class AppoinmentTest : AbstractSetup
     {
         LoginTests lt = new LoginTests(); //object of class LoginTests
         
        public AppoinmentTest(Platform platform) : base(platform)
        {
        }
        
    
        public void CreateAppoinment() { 
           lt.Login_SuccessfullAuthentication_SuccessfullLogin()              //Here i want to call the login method before doing below functionality
            app.Tap(x => x.Text("Sign in"));
            app.WaitForElement(x => x.Id("action_bar_title"), timeout:     TimeSpan.FromSeconds(10));
            app.Tap(x => x.Id("action_bar_title"));
            }}
    }
