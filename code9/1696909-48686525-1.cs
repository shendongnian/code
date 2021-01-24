    private readonly IHttpClient client;
	public AddressBookController(IHttpClient client) {
	    this.client = client;
	}
	[HttpGet("getAddressBook")]
    public async Task<IActionResult> GetAddressBook() { 
		var AddressBookInfo = await client.GetAsync<AddressBookRootObject>("/v1/addressBook_get");
		if (AddressBookInfo != null) {
			return Ok(AddressBookInfo.data);
		} else  {
			return BadRequest("Error retrieving data from atCom server");
		}
    }
	
