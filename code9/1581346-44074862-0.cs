    private void BtnConsumer_Click(object sender, EventArgs e)
    {
        CustomProgressDialog progressDialog = CustomProgressDialog.Show(this);
        try
        {
            String cpfConsumer = edtCpf.Text;
            Pessoa pessoa = this.GetConsumer(cpfConsumer);
            List<String> lista = this.GetServiceOrders(cpfConsumer);
            txtnome.Text = "Nome: " + pessoa.firstName + " " + pessoa.lastName;
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, lista);
            mlistview.Adapter = adapter;
        catch (Exception ex)
        {
            Toast.MakeText(this, "EXCEPTION: " + ex.Message, ToastLength.Long).Show();
        }
        progressDialog.Dismiss();
    }
    private Pessoa GetConsumer(String cpfConsumer)
    {
        // API Consumer CPF
        RestClient client = new RestClient("https://qa.api-latam.whirlpool.com/v1.0/consumers");
        RestRequest requestConsumer = new RestRequest("/" + cpfConsumer, Method.GET);
        requestConsumer.AddHeader("Content-Type", "application/json; charset=utf-8");
        requestConsumer.AddHeader("Authorization", "Bearer fed6b2f0-7aba-3339-9813-7fc9387e2581");
        IRestResponse responseConsumer = consumer.Execute(cpfConsumer);
        Pessoa pessoa = JsonConvert.DeserializeObject<Pessoa>(responseConsumer.Content);
        return pessoa;
    }
    private List<String> GetServiceOrders(String cpfConsumer)
    {
        // API Consumer service-orders
        RestClient client = new RestClient("https://qa.api-latam.whirlpool.com/v1.0/consumers/");
        RestRequest ordersRequest = new RestRequest("/" + cpfConsumer + "/service-orders", Method.GET);
        ordersRequest.AddHeader("Content-Type", "application/json; charset=utf-8");
        ordersRequest.AddHeader("Authorization", "Bearer fed6b2f0-7aba-3339-9813-7fc9387e2581");
        IRestResponse ordersResponse = client.Execute(requestorderId);
        RootObject ordersObject = JsonConvert.DeserializeObject<RootObject>(ordersResponse.Content);
        List<String> lista = new List<String>();
        for (int i = 0; i < ordersObject.orders.Count; i++)
        {
            String s = ordersObject.orders[i].order.orderId + " " + "StatusCode" + " - " + ordersObject.orders[i].order.orderStatusCode + " " + "Status Description: " + " - " + ordersObject.orders[i].order.orderStatusDescription;
            lista.Add(s);
        }
    }
