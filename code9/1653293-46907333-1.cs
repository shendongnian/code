    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    
    namespace Project1
    {
        public partial class SiteMaster : MasterPage
        {
            private const string AntiXsrfTokenKey = "__AntiXsrfToken";
            private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
            private string _antiXsrfTokenValue;
    
            protected void Page_Init(object sender, EventArgs e)
            {
                // Il codice seguente facilita la protezione da attacchi XSRF
                var requestCookie = Request.Cookies[AntiXsrfTokenKey];
                Guid requestCookieGuidValue;
                if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
                {
                    // Utilizzare il token Anti-XSRF dal cookie
                    _antiXsrfTokenValue = requestCookie.Value;
                    Page.ViewStateUserKey = _antiXsrfTokenValue;
                }
                else
                {
                    // Generare un nuovo token Anti-XSRF e salvarlo nel cookie
                    _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                    Page.ViewStateUserKey = _antiXsrfTokenValue;
    
                    var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                    {
                        HttpOnly = true,
                        Value = _antiXsrfTokenValue
                    };
                    if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                    {
                        responseCookie.Secure = true;
                    }
                    Response.Cookies.Set(responseCookie);
                }
    
                Page.PreLoad += master_Page_PreLoad;
            }
    
            protected void master_Page_PreLoad(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    // Impostare il token Anti-XSRF
                    ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                    ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
                }
                else
                {
                    // Convalidare il token Anti-XSRF
                    if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                        || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                    {
                        throw new InvalidOperationException("Convalida del token Anti-XSRF non riuscita.");
                    }
                }
            }
            public void ClearSelectionClienti()
            {
                drlClienti.ClearSelection();
            }
            protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
            {
                Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                Session["gruppo"] = null;
                Response.Redirect("/Account/Login.aspx");
            }
    
            protected void drlClienti_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (drlClienti.SelectedIndex != -1)
                {
                    Session["cliente"] = drlClienti.SelectedValue.ToString();
                    Response.Redirect(Request.RawUrl);
                }
            }
    
            protected void drlClienti_DataBound(object sender, EventArgs e)
            {
                if (Session["cliente"] != null)
                {
                    drlClienti.SelectedValue = Session["cliente"].ToString();
                }
                else
                {
                    drlClienti.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                    drlClienti.SelectedIndex = 0;
                }
            }
        }
    
    }
