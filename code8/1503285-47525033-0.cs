    public class myWS : System.Web.Services.WebService
    {
        public string Token { get; set; }
    
        Public void SetToken(string myToken){
          this.Token= myToken;
        }
    
        Public void Method1(){
          BLL.CheckToken1(Token);
        }
    
        Public void Method2(){
          BLL.CheckToken2(Token);
        }
     }
