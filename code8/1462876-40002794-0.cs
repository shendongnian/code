       [HtmlTargetElement("img", TagStructure = TagStructure.WithoutEndTag)]
        public class ImageTagHelper : TagHelper
        {
            public ImageTagHelper(IUrlHelperFactory urlHelperFactory,
                                  IActionContextAccessor actionContextAccessor,
                                  IHostingEnvironment environment)
            {
                _urlHelperFactory = urlHelperFactory;
                _actionContextAccessor = actionContextAccessor;
                _env = environment;
            }
    
            private IUrlHelperFactory _urlHelperFactory;
            private IActionContextAccessor _actionContextAccessor;
    
            private IHostingEnvironment _env;
    
            public string DefaultImageSrc { get; set; }
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                string imgPath = context.AllAttributes["src"].Value.ToString();
    
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
    
                if (!imgPath.StartsWith("data:"))
                {
                    if (!File.Exists(_env.WebRootPath + urlHelper.Content(imgPath)))
                    {
                        if (DefaultImageSrc != null)
                        {
                            output.Attributes.SetAttribute("src", urlHelper.Content(DefaultImageSrc));
                        }
                    }
                }
            }
    
        }
