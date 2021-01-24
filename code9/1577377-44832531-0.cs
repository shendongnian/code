        try
		{
			LyncClient lyncClient = LyncClient.GetClient();
			Contact contact;
			List<object> endPoints = new List<object>();
			Dictionary<string, string> phoneNumbers = new Dictionary<string, string>();
			contact = lyncClient.ContactManager.GetContactByUri("sip:myusername@domain.com"); //PASS THE SIP ADDRESS HERE
			var telephoneNumber = (List<object>)contact.GetContactInformation(ContactInformationType.ContactEndpoints);
			//var contactName = contact.GetContactInformation(ContactInformationType.DisplayName).ToString();
			//var availability = contact.GetContactInformation(ContactInformationType.Activity).ToString();
			//foreach (object endPoint in telephoneNumber)
			//{
			//Console.WriteLine(((ContactEndpoint)endPoint).DisplayName + " " + ((ContactEndpoint)endPoint).Type.ToString());
			//}
			endPoints = telephoneNumber.Where<object>(N => ((ContactEndpoint)N).Type == ContactEndpointType.HomePhone || ((ContactEndpoint)N).Type == ContactEndpointType.MobilePhone || ((ContactEndpoint)N).Type == ContactEndpointType.OtherPhone || ((ContactEndpoint)N).Type == ContactEndpointType.WorkPhone).ToList<object>();
			foreach (var endPoint in endPoints)
			{
						//Console.WriteLine(((ContactEndpoint)test).DisplayName.ToString());
				string numberType = Regex.Replace(((ContactEndpoint)endPoint).Type.ToString(), @"Phone", "");
				//string number = Regex.Replace(((ContactEndpoint)endPoint).DisplayName.ToString(), @"[^0-9]", "");
				string number = "";
				//Numbers only with dashes
                if (Regex.IsMatch(((ContactEndpoint)endPoint).DisplayName.ToString(), @"^\d{3}-\d{3}-\d{4}$"))
				{
					number = ((ContactEndpoint)endPoint).DisplayName.ToString();
					try
					{
						phoneNumbers.Add(numberType, number);
					}
					catch
					{
					}
				}
				//Console.WriteLine(numberType + " " + number);
			}
			foreach (var entry in phoneNumbers)
			{
				//entry.Key is the PhoneType
				//entry.Value is the Phone Number
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("An error occurred: " + ex.Message);
		}
