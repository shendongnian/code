    public class Startup {
    
    	public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
    
    		var options = new RewriteOptions()
    			.AddRedirect("(.*)/$", "$1")                    // Redirect using a regular expression
    			.AddRewrite(@"app/(\d+)", "app?id=$1", skipRemainingRules: false) // Rewrite based on a Regular expression
    			.AddRedirectToHttps(302, 5001)                  // Redirect to a different port and use HTTPS
    			.AddIISUrlRewrite(env.ContentRootFileProvider, "UrlRewrite.xml")        // Use IIS UrlRewriter rules to configure
    			.AddApacheModRewrite(env.ContentRootFileProvider, "Rewrite.txt");       // Use Apache mod_rewrite rules to configure
    
    		app.UseRewriter(options);
    	}	
    }
