    addMessage(textToSend: string) {
        let body = JSON.stringify({ textToSend });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post("/api/SendMessage/", body, options);
    }
    
    // Server side -1
    [HttpPost]
    [Route("/api/SendMessage")]
    public void SendMessage([FromBody]IDictionary<string, string> msg)
    {
        var textToSend = msg["textToSend"];
    }
    // Or create a model and use it
    //Server side -2
    public class Model
    {
        public string textToSend { get; set; }
    }
    public void SendMessage([FromBody]Model model)
