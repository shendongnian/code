    const string cw_app_id = "<YourAppID>";
    const string cw_site = "<YourConnectWiseInstance>";
    const string cw_companyname = "<YourConnectWiseCompany>";
    const string public_key = "<PublicKey>";
    const string private_key = "<PrivateKey>";
    private static ApiClient GetApiClient()
    {
        return new ApiClient(cw_app_id, cw_site, cw_companyname)
                   .SetPublicPrivateKey(public_key, private_key);
    }
    private static List<Invoice> getInvoices()
    {
        var client = getApiClient();
        var invoicesApi = new InvoiceApi(client);
        var response = invoicesApi.GetInvoices();
        var invoices = response.GetResult<List<Invoice>>();
        foreach (var invoice in invoices)
        {
            Console.WriteLine(invoice.invoiceNumber);
        }
        return invoices;
    }
