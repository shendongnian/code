    using Microsoft.Bot.Builder.FormFlow;
    using Microsoft.Bot.Builder.FormFlow.Advanced;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    namespace pc.Bot.Form
    {
        [Serializable]
        public class MyForm
        {
            public MyForm(List<string> Names) { _names = Names; }
        
            List<string> _names;
           [Template(TemplateUsage.NotUnderstood, "**{0}** isn't a valid selection",  ChoiceStyle = ChoiceStyleOptions.PerLine)]
           [Prompt("**Choose from the following names**:  {||}")]
           public List<string> Names { get; set; }
           public static IForm<MyForm> BuildForm() {
                return new FormBuilder<MyForm>()
                 .Field(new FieldReflector<MyForm>(nameof(Names))
                    .SetType(null)
                    .SetActive(form => form._names != null && form._names.Count > 0)
                    .SetDefine(async (form, field) =>
                    {
                        form?._names.ForEach(name=> field.AddDescription(name, name).AddTerms(name, name));
                        return await Task.FromResult(true);
                    }))
                .Build();
            }
        }
    }
