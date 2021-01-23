        using Facebook;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    
    namespace FaceTest.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.UrlFb = GetFacebookLoginUrl();
                return View();
            }
    
            public ActionResult About()
            {
                //ViewBag.Message = "Your application description page.";
                ViewBag.Name = !String.IsNullOrEmpty(GetProfileName()) ? GetProfileName() : "Inicia Sesión";
                ViewBag.Id = !String.IsNullOrEmpty(GetProfileId()) ? GetProfileId() : "Inicia Sesión";
                return View();
            }
    
            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";
    
                return View();
            }
    
            public string GetFacebookLoginUrl()
            {
                dynamic parameters = new ExpandoObject();
                parameters.client_id = "1766341193627031";
                parameters.redirect_uri = "http://localhost:51518/Home/RetornoFb/";
                parameters.response_type = "code";
                parameters.display = "page";
    
                var extendedPermissions = "publish_actions";
                parameters.scope = extendedPermissions;
    
                var _fb = new FacebookClient();
                var url = _fb.GetLoginUrl(parameters);
    
                return url.ToString();
            }
    
            public ActionResult RetornoFb()
            {
                var _fb = new FacebookClient();
                FacebookOAuthResult oauthResult;
    
                if(!_fb.TryParseOAuthCallbackUrl(Request.Url, out oauthResult))
                {
                    // Error
                }
    
                if (oauthResult.IsSuccess)
                {
                    //Pega o Access Token "permanente"
                    dynamic parameters = new ExpandoObject();
                    parameters.client_id = "1766341193627031";
                    parameters.redirect_uri = "http://localhost:51518/Home/RetornoFb/";
                    parameters.client_secret = "52cee8ef9437e4981302c24a66e13d55";
                    parameters.code = oauthResult.Code;
    
                    dynamic result = _fb.Get("/oauth/access_token", parameters);
    
                    var accessToken = result.access_token;
    
                    //TODO: Guardar no banco
                    Session.Add("FbUserToken", accessToken);
                }
                else
                {
                    // tratar
                }
    
                return RedirectToAction("Index");
            }
    
            public ActionResult DetalhesDoUsuario()
            {
                if (Session["FbuserToken"] != null)
                {
                    var _fb = new FacebookClient(Session["FbuserToken"].ToString());
    
                    //detalhes do usuario
                    var request = _fb.Get("me");
                    var a = request;
                }
    
                return RedirectToAction("Index");
            }
    /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
            /* public string GetName(string externalToken)
             {
                 FacebookClient client = new FacebookClient(externalToken);
                 dynamic resultMe = client.Get("me?fields=id,name");
    
                 return resultMe.Name;
             }*/
    
            public string GetProfileName()
            {
                if (Session["FbuserToken"] != null)
                {
                    try
                    {
                        var _fb = new FacebookClient(Session["FbuserToken"].ToString());
                        dynamic resultMe = _fb.Get("me?fields=first_name");
                        return resultMe.first_name;
                    }
                    catch (FacebookOAuthException)
                    {
                        return null;
                    }
                }
    
                return null;
            }
    
            public string GetProfileId()
            {
    
                if (Session["FbuserToken"] != null)
                {
                    try
                    {
                        var _fb = new FacebookClient(Session["FbuserToken"].ToString());
                        dynamic resultMe = _fb.Get("me?fields=id");
                        return resultMe.id;
                    }
                    catch (FacebookOAuthException)
                    {
                        return null;
                    }
                }
    
                return null;
            }
            /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
            /*public byte[] GetPhoto(string userId)
                {
                    try
                    {
                        string url = "https://graph.facebook.com/" + userId + 
                                     "?fields=picture.width(720).height(720)";
    
                        WebClient webClient = new WebClient();
                        string response = webClient.DownloadString(url);
    
                        dynamic json = JObject.Parse(response);
    
                        string urlPicture = json.picture.data.url;
    
                        return webClient.DownloadData(urlPicture);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }*/
            public byte[] GetPhoto()
            {
                try
                {
                    string url = "https://graph.facebook.com/" + GetProfileId() +"?fields=picture.width(480).height(480)";
    
                    WebClient webClient = new WebClient();
                    string response = webClient.DownloadString(url);
    
                    dynamic json = JObject.Parse(response);
    
                    string urlPicture = json.picture.data.url;
    
                    return webClient.DownloadData(urlPicture);
                }
                catch (Exception)
                {
                    return null;
                }
            }
    /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
    /*  */
    /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
    
        /*
         protected IEnumerable<string> GetFriendIds(string externalToken)
            {
                FacebookClient client = new FacebookClient(externalToken);
                dynamic result = client.Get("me/friends");
      
                foreach (dynamic friend in result.data)
                {
                    yield return friend.id;
                }
            }
        */
    /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
            public ActionResult ListarAmigos()
            {
                if (Session["FbuserToken"] != null)
                {
                    var _fb = new FacebookClient(Session["FbuserToken"].ToString());
    
                    //listar os amigos
                    var request = _fb.Get("me/friends");
                    var a = request;
                }
    
                return RedirectToAction("Index");
    
            }
    /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        /*
        public void Share(string userId, string externalToken, Yipi yipi)
            {
                dynamic messagePost = new ExpandoObject();
                messagePost.link = GetYipiUrl(yipi);
                messagePost.message = string.Format(TextMessage, yipi.Message);
      
                FacebookClient client = new FacebookClient(externalToken);
                client.Post(userId + "/feed", messagePost);
            } 
        */
    /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
            public ActionResult PublicarMensagem()
            {
                if (Session["FbuserToken"] != null)
                {
                    var _fb = new FacebookClient(Session["FbuserToken"].ToString());
    
                    //Postar uma mensagem na timeline
                    dynamic messagePost = new ExpandoObject();
                    messagePost.picture = "http://www.rodolfofadino.com.br/wp-content/uploads/2013/12/image_thumb10.png";
                    messagePost.link = "http://www.rodolfofadino.com.br/2013/12/test-mode-values-para-o-microsoft-advertising-sdk-windows-8/";
                    messagePost.name = "Post name...";
                    messagePost.caption = " Post Caption";
                    messagePost.description = "post description";
                    messagePost.message = "Mensagem de testes da aplicação";
    
                    try
                    {
                        var postId = _fb.Post("me/feed", messagePost);
                    }
                    catch (FacebookOAuthException ex)
                    {
                        //handle oauth exception
                    }
                    catch (FacebookApiException ex)
                    {
                        //handle facebook exception
                    }
                }
    
                return RedirectToAction("Index");
            }
    
            public ActionResult PublicarFoto()
            {
                if (Session["FbuserToken"] != null)
                {
                    var _fb = new FacebookClient(Session["FbuserToken"].ToString());
                    //upload de imagem
                    FacebookMediaObject media = new FacebookMediaObject
                    {
                        FileName = "Nome da foto",
                        ContentType = "image/jpeg"
                    };
    
                    byte[] img = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/rodolfo.jpg"));
                    media.SetValue(img);
    
                    dynamic parameters = new ExpandoObject();
    
                    parameters.source = media;
                    parameters.message = "Descricao";
    
                    try
                    {
                        dynamic result = _fb.Post("/me/photos", parameters);
    
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return RedirectToAction("Index");
            }
        }
    }
