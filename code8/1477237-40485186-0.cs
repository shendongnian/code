	private static Cookie ConfigurarAcessoGED() {
	  IMpsSettingsServico servMpsSettings = Servico.Obter<IMpsSettingsServico>();
	  MpsSettings mpsSettings = servMpsSettings.ObterConfiguracoes();
	  Uri uri = new Uri(mpsSettings.UrlLoginGED);
	  var req = new HttpRequestMessage(HttpMethod.Post, uri);
	  var reqBody = @"{
		  'userName':'USERNAME',
		  'password':'PASSWORD'
		}";
	  req.Content = new StringContent(reqBody, Encoding.UTF8, "application/json");
	  CookieContainer cookies = new CookieContainer();
	  HttpClientHandler handler = new HttpClientHandler();
	  handler.CookieContainer = cookies;
	  HttpClient client = new HttpClient(handler);
	  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
	  HttpResponseMessage resp = null;
	  try {
		resp = client.SendAsync(req).Result;
	  } catch (Exception ex) {
		throw new Exception("Something went wrong");
	  }
	  if (!resp.IsSuccessStatusCode) {
		string message;
		if (resp.StatusCode == HttpStatusCode.Unauthorized || resp.StatusCode == HttpStatusCode.Forbidden || resp.StatusCode == HttpStatusCode.Redirect)
		  message = "Permission denied.";
		else
		  message = resp.ReasonPhrase;
		throw new Exception(message);
	  }
	  IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
	  if (responseCookies.FirstOrDefault() != null)
		return responseCookies.FirstOrDefault();
	  return null;
	}
