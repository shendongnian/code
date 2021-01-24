    @inherits Umbraco.Web.Mvc.UmbracoTemplatePage
    @using Newtonsoft.Json.Linq
    @{
        // First get the homepage by traversing the Umbraco tree and searching for the homepage node
        var homepage = Umbraco.TypedContentAtRoot().First().DescendantsOrSelf().FirstOrDefault(x => x.DocumentTypeAlias == "home");
        if (homepage != null && homepage.HasValue("externalLinks") && homepage.GetPropertyValue<string>("externalLinks").Length > 2)
        {
            <ul>
                @{
                    var externalLinks = homepage.GetPropertyValue<JArray>("externalLinks");
                    foreach (var item in externalLinks)
                    {
                        var linkTarget = item.Value<bool>("newWindow") ? "_blank" : null;
                        if (externalLinks.First() == item)
                        {
                            <li>
                                <a href="@(item.Value<string>("link"))" target="@linkTarget"> <i class="fa fa-phone" aria-hidden="true"></i> @(item.Value<string>("caption"))</a>
                            </li>
                        }
                        else
                        {
                            <li>
                                <a href="@(item.Value<string>("link"))" target="@linkTarget"> <i class="fa fa-flag" aria-hidden="true"></i> @(item.Value<string>("caption"))</a>
                            </li>
                        }
                    }
                }
            </ul>
        }
    }
