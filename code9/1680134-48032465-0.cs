    public enum Genders { none, Male, Female, Other };
    [Serializable]
    public class RegisterPatientForm
    {
        [Prompt("What is the patient`s name?")]
        public string person_name;
        [Prompt("What is the patients gender? {||}")]
        public Genders gender;
        [Prompt("What is the patients phone number?")]
        [Pattern(@"(<Undefined control sequence>\d)?\s*\d{3}(-|\s*)\d{4}")]
        public string phone_number;
        [Prompt("What is the patients Date of birth?")]
        public DateTime DOB;
        [Prompt("What is the patients CNIC number?")]
        public string cnic;
        public static IForm<RegisterPatientForm> BuildForm()
        {
            OnCompletionAsyncDelegate<RegisterPatientForm> processHotelsSearch = async (context, state) =>
            {
                await context.PostAsync($"Patient {state.person_name} registered");
            };
            return new FormBuilder<RegisterPatientForm>()
                .Field(nameof(person_name),
                validate: async (state, response) =>
                {
                    var result = new ValidateResult { IsValid = true, Value = response };
                    
                    //Query LUIS and get the response
                    LUISOutput LuisOutput = await GetIntentAndEntitiesFromLUIS((string)response);
                    
                    //Now you have the intents and entities in LuisOutput object
                    //See if your entity is present and then retrieve the value
                    LUISEntity LuisEntity = Array.Find(LuisOutput.entities, entity => entity.Type == "name");
                    
                    if (LuisEntity != null)
                    {
                        //Store the found response in result
                        result.Value = LuisEntity.Entity;
                    }
                    else
                    {
                        //Name not found in the response
                        result.IsValid = false;
                    }
                    return result;
                })
                .Field(nameof(gender))
                .Field(nameof(phone_number))
                .Field(nameof(DOB))
                .Field(nameof(cnic))
                .OnCompletion(processHotelsSearch)
                .Build();
        }
        public static async Task<LUISOutput> GetIntentAndEntitiesFromLUIS(string Query)
        {
            Query = Uri.EscapeDataString(Query);
            LUISOutput luisData = new LUISOutput();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string RequestURI = WebConfigurationManager.AppSettings["LuisModelEndpoint"] + Query;
                    HttpResponseMessage msg = await client.GetAsync(RequestURI);
                    if (msg.IsSuccessStatusCode)
                    {
                        var JsonDataResponse = await msg.Content.ReadAsStringAsync();
                        luisData = JsonConvert.DeserializeObject<LUISOutput>(JsonDataResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return luisData;
        }
    }
