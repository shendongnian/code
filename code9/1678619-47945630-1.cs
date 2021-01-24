    public class TargetTagHelper : TagHelper
    {
         public string DestinationName { get; set; }
        
         public override Process(TagHelperContext context, TagHelperOutput output)
         {
              output.TagName = "a";
      
              var  url = GetHyperLinkAttributes<Navigation>(DestinationName);
              output.Attributes.SetAttribute("href", url);
              output.Content.SetContent(url);
         }
    }
