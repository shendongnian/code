            // instantiate api client with appropriate environment (for production change to www.docusign.net/restapi)
            configureApiClient("https://demo.docusign.net/restapi");
            //===========================================================
            // Step 1: Login()
            //===========================================================
            // call the Login() API which sets the user's baseUrl and returns their accountId
            AccountId = loginApi(username, password);
            //===========================================================
            // Step 2: Signature Request from Template 
            //===========================================================
            EnvelopeDefinition envDef = new EnvelopeDefinition();
            envDef.EmailSubject = "Please sign this sample template document11111111111";
            // assign recipient to template role by setting name, email, and role name.  Note that the
            // template role name must match the placeholder role name saved in your account template.  
            TemplateRole tRole = new TemplateRole();
            tRole.Email = recipientEmail;
            tRole.Name = recipientName;
            tRole.RoleName = templateRoleName;
            List<TemplateRole> rolesList = new List<TemplateRole>() { tRole };
            // add the role to the envelope and assign valid templateId from your account
            envDef.TemplateRoles = rolesList;
            envDef.TemplateId = templateId;
            // set envelope status to "sent" to immediately send the signature request
            envDef.Status = "sent";
            List<TextCustomField> customFieldsTextList = new List<TextCustomField>();
            if (data.CustomFieldsText != null)
            {
                //custom text fields
                foreach (DocuSignCustomField customField in data.CustomFieldsText)
                {
                    TextCustomField newField = new TextCustomField();
                    newField.Name = customField.Name;
                    newField.Value = customField.Value;
                    newField.Show = customField.Show;
                    newField.Required = customField.Required;
                    customFieldsTextList.Add(newField);
                }
            }
            CustomFields customFields = new CustomFields();
            customFields.TextCustomFields = customFieldsTextList;
            envDef.CustomFields = customFields;
            // |EnvelopesApi| contains methods related to creating and sending Envelopes (aka signature requests)
            EnvelopesApi envelopesApi = new EnvelopesApi();
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(AccountId, envDef);
            // print the JSON response
            //Console.WriteLine("Envelope Template Summary:\n{0}", JsonConvert.SerializeObject(envelopeSummary));
            return envelopeSummary;
        } // end requestSignatureFromTemplateTest()
