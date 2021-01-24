    <siteMap>
      <providers>
        <!-- Add this next line: -->
        <clear/>
        <add name="Admin" type="System.Web.XmlSiteMapProvider" siteMapFile="~/MenuSystem/Admin.sitemap" />
        <add name="Branch" type="System.Web.XmlSiteMapProvider" siteMapFile="~/MenuSystem/Branch.sitemap" />
        <add name="Supplier" type="System.Web.XmlSiteMapProvider" siteMapFile="~/MenuSystem/web.sitemap" />
      </providers>
    </siteMap>
