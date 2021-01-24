    [Serializable]
    public class SimpleForm
    {
        public string Name;
        
        [Numeric(1, 5)]
        [Prompt("Your experience with the form")]
        public float? Rating;
    
        public static IForm<SimpleForm> BuildForm()
        {
            return new FormBuilder<SimpleForm>()
                    .Field(nameof(Rating))
                    .Field(new FieldReflector<SimpleForm>(nameof(Name))
                        .SetDefine(DefinitionMethod))
                    .Build();
        }
    
        private static async Task<bool> DefinitionMethod(SimpleForm state, Field<SimpleForm> field)
        {
            field.SetPrompt(new PromptAttribute($"You chose a rating of {state.Rating}. What is your name?."));
            return true;
        }
    }
