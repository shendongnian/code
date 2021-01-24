    [SitecoreType(TemplateId = "{1CF86642-6EC5-4B26-B8A7-1B2EC41F7783}", AutoMap = true)]
    public class RecipeViewModel : BaseFields
    {
        [SitecoreId]
        public ID Id { get; set; }
        public virtual string RecipeName { get; set; }
        public virtual string BookName { get; set; }
        [SitecoreField(FieldId = "{D1603482-7CBC-4E55-9CCB-E51DC0FC5A0B}", FieldType = SitecoreFieldType.Multilist)]
        public virtual IEnumerable<IngredientViewModel> Ingredients { get; set; }
        public virtual int AmountOfPeople { get; set; }
    }
