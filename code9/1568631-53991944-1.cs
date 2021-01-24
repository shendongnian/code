    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    
    public class ComponentTestStartup : IStartup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            return services.BuildServiceProvider();
        }
    
        public void Configure(IApplicationBuilder app)
        {
        }
    } 
    
    public class ComponentTestServerFixture : WebApplicationFactory<ComponentTestStartup>
    {
        public TService GetRequiredService<TService>()
        {
            if (Server == null)
            {
                CreateDefaultClient();
            }
    
            return Server.Host.Services.GetRequiredService<TService>();
        }
    
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var hostBuilder = new WebHostBuilder();
            return hostBuilder.UseStartup<ComponentTestStartup>();
        }
    
        // uncomment if your test project isn't in a child folder of the .sln file
        // protected override void ConfigureWebHost(IWebHostBuilder builder)
        // {
        //    builder.UseSolutionRelativeContentRoot("relative/path/to/test/project");
        // }
    }
    
    public class RazorViewToStringRendererTests
    {
        private readonly RazorViewToStringRenderer viewRenderer;
    
        public RazorViewToStringRendererTests()
        {
            var server = new ComponentTestServerFixture();
            var serviceProvider = server.GetRequiredService<IServiceProvider>();
            var viewEngine = server.GetRequiredService<IRazorViewEngine>();
            var tempDataProvider = server.GetRequiredService<ITempDataProvider>();
            viewRenderer = new RazorViewToStringRenderer(viewEngine, tempDataProvider, serviceProvider);
        }
    
        [Fact]
        public async Task CanRenderViewToString()
        {
            // arrange
            var model = "test model";
    
            // act
            var renderedView = await viewRenderer.RenderViewToStringAsync("/Path/To/TestView.cshtml", model);
    
            // assert
            Assert.NotNull(renderedView);
            Assert.Contains(model, renderedView, StringComparison.OrdinalIgnoreCase);
        }
    }
