    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using YamlDotNet.Core;
    using YamlDotNet.Serialization;
    using YamlDotNet.Serialization.NamingConventions;
    using YamlDotNet.Serialization.TypeInspectors;
    
    namespace SwaggerPhun
    {
        public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
    
            public IConfiguration Configuration { get; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
    
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "File Comment API",
                        Description = "A simple example ASP.NET Core Web API",
                        //TermsOfService = "None",
                        Contact = new Contact
                        {
                            Name = "Pawel Gorczynski",
                            Email = "pawel.gorczynski@devfactory.com",
                        },
                        License = new License
                        {
                            Name = "Use under LICX",
                            Url = "https://example.com/license"
                        },
                    });
                    c.DocumentFilter<YamlDocumentFilter>();
    
                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });
    
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
    
                app.UseMvc();
    
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
    
                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
    
            private class YamlDocumentFilter : IDocumentFilter
            {
                public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
                {
                    var builder = new SerializerBuilder();
                    builder.WithNamingConvention(new HyphenatedNamingConvention());
                    builder.WithTypeInspector(innerInspector => new PropertiesIgnoreTypeInspector(innerInspector));
    
                    var serializer = builder.Build();
    
                    using (var writer = new StringWriter())
                    {
                        serializer.Serialize(writer, swaggerDoc);
    
                        var file = AppDomain.CurrentDomain.BaseDirectory + "swagger_yaml.txt";
                        using (var stream = new StreamWriter(file))
                        {
                            var result = writer.ToString();
                            stream.WriteLine(result.Replace("2.0", "\"2.0\"").Replace("ref:", "$ref:"));
                        }
                    }
                }
            }
    
            private class PropertiesIgnoreTypeInspector : TypeInspectorSkeleton
            {
                private readonly ITypeInspector _typeInspector;
    
                public PropertiesIgnoreTypeInspector(ITypeInspector typeInspector)
                {
                    this._typeInspector = typeInspector;
                }
    
                public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
                {
                    return _typeInspector.GetProperties(type, container).Where(p => p.Name != "extensions" && p.Name != "operation-id");
                }
    
            }
        }
    }
