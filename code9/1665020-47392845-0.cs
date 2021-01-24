    public class BarcodeResultDto
        {
            [JsonProperty("httpInformation")]
            public string HttpInformation { get; set; }
    
            [JsonProperty("httpWarning")]
            public string HttpWarning { get; set; }
    
            [JsonProperty("httpResponseCode")]
            public int GetHttpResponseCode { get; set; }
        }
    public IActionResult DecodeBarcode(string productCodeScheme, string productCode, string serialNumber,
                string batch, string expirationDate, int commandStatusCode)
            {
                var barcodeResult = new BarcodeResultDto
                {
                    GetHttpResponseCode = 200,
                    HttpInformation = "The pack is active",
                    HttpWarning = "No Warning"
                };
                // your code here
                return Ok(barcodeResult);
            }
