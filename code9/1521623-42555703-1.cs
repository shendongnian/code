    using System;
    using System.IO.Packaging;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Navigation;
    
    namespace Extensions
    {
       public static class WpfWindowExtensions
       {
          // https://stackoverflow.com/questions/7646331/the-component-does-not-have-a-resource-identified-by-the-uri
          public static void LoadViewFromUri( this Window window, string baseUri )
          {
             try
             {
                var resourceLocater = new Uri( baseUri, UriKind.Relative );
                // log.Info( "Resource locator is: ")
                var exprCa = ( PackagePart )typeof( Application ).GetMethod( "GetResourceOrContentPart", BindingFlags.NonPublic | BindingFlags.Static ).Invoke( null, new object[] { resourceLocater } );
                var stream = exprCa.GetStream();
                var uri = new Uri( ( Uri )typeof( BaseUriHelper ).GetProperty( "PackAppBaseUri", BindingFlags.Static | BindingFlags.NonPublic ).GetValue( null, null ), resourceLocater );
                var parserContext = new ParserContext
                {
                   BaseUri = uri
                };
                typeof( XamlReader ).GetMethod( "LoadBaml", BindingFlags.NonPublic | BindingFlags.Static ).Invoke( null, new object[] { stream, parserContext, window, true } );
             }
             catch( Exception )
             {
                //log
             }
          }
       }
    }
