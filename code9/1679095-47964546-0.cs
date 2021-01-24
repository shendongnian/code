    [HttpGet()]
    public async Task<HttpResponseMessage> Get([FromUri]int oid) {
        var orderdetails = _orderServices.GetOrderDetails(oid);
        var xml = new XmlMediaTypeFormatter();
        xml.UseXmlSerializer = true;
        string orderdetailsser = Serialize(xml, orderdetails);
        var result = await PostXml(orderdetailsser);
        return Request.CreateResponse(HttpStatusCode.OK);
    }
    public static async Task<HttpResponseMessage> PostXml(string str) {
        using(var client = new HttpClient()) {
            client.BaseAddress = new Uri("http://localhost:58285/");
            var content = new StringContent(str);
            var response = await client.PostAsync("api/default/ReceiveXml", content).ConfigureAwait(false);
            return response;
        }
    }
    [HttpPost()]
    public async Task<HttpResponseMessage> ReceiveXml(HttpRequestMessage request) {
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(await request.Content.ReadAsStreamAsync());
        xmlDoc.Save(@"C:\xmlfiles\xml2.xml");
        XmlSerializer deserializer = new XmlSerializer(typeof(OrderInfoModel));
        TextReader reader = new StreamReader(@"C:\xmlfiles\xml2.xml");
        object obj = deserializer.Deserialize(reader);
        OrderInfoModel orderdetails = (OrderInfoModel)obj;
        reader.Close();
        var patient_id = _patientServices.ProcessPatient(orderdetails.Patient, orderdetails.OrderInfo);
        var orderid = _orderServices.ProcessOrder(orderdetails.Patient, orderdetails.OrderInfo, patient_id);
        if(orderdetails.OrderNotes != null && orderdetails.OrderNotes.Count() > 0) {
            var success = _orderServices.ProcessOrderNotes(orderid, orderdetails.OrderNotes);
        }
        var prvid = _orderServices.ProcessOrderProvider(orderid, orderdetails.ReferringProvider);
        var shpngid = _orderServices.ProcessOrderShipping(orderid, orderdetails.ShippingInfo);
        var payerid = _orderServices.ProcessOrderPayer(orderid, orderdetails.Insurances);
        return Request.CreateResponse(HttpStatusCode.OK, orderid);
    }
