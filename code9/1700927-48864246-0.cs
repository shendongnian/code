    [HtmlTargetElement("input", TagStructure = TagStructure.WithoutEndTag)]
    public class MyTagHelper : Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper
    {
    	[HtmlAttributeName("asp-short-name")]
    	public bool IsShortName { set; get; }
    
    	public MyTagHelper(IHtmlGenerator generator) : base(generator)
    	{
    	}
    
    	public override void Process(TagHelperContext context, TagHelperOutput output)
    	{
    		if (IsShortName)
    		{
    			string nameAttrValue = (string)output.Attributes.Single(a => a.Name == "name").Value;
    			output.Attributes.SetAttribute("name", nameAttrValue.Split('.').Last());
    		}
    		base.Process(context, output);
    	}
    }
