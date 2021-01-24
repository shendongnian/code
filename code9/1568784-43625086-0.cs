    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    
        namespace Microsoft.Practices.Unity
        {
            //
            // Summary:
            //     Extension class that adds a set of convenience overloads to the Microsoft.Practices.Unity.IUnityContainer
            //     interface.
            public static class UnityContainerExtensions
            {
                //
            // Summary:
            //     Resolve an instance of the default requested type from the container.
            //
            // Parameters:
            //   container:
            //     Container to resolve from.
            //
            //   overrides:
            //     Any overrides for the resolve call.
            //
            // Type parameters:
            //   T:
            //     System.Type of object to get from the container.
            //
            // Returns:
            //     The retrieved object.
            public static T Resolve<T>(this IUnityContainer container, params ResolverOverride[] overrides);
            //
            // Summary:
            //     Resolve an instance of the requested type with the given name from the container.
            //
            // Parameters:
            //   container:
            //     Container to resolve from.
            //
            //   name:
            //     Name of the object to retrieve.
            //
            //   overrides:
            //     Any overrides for the resolve call.
            //
            // Type parameters:
            //   T:
            //     System.Type of object to get from the container.
            //
            // Returns:
            //     The retrieved object.
            public static T Resolve<T>(this IUnityContainer container, string name, params ResolverOverride[] overrides);
            //
            // Summary:
            //     Return instances of all registered types requested.
            //
            // Parameters:
            //   container:
            //     Container to resolve from.
            //
            //   resolverOverrides:
            //     Any overrides for the resolve calls.
            //
            // Type parameters:
            //   T:
            //     The type requested.
            //
            // Returns:
            //     Set of objects of type T.
            //
            // Remarks:
            //     This method is useful if you've registered multiple types with the same System.Type
            //     but different names.
            //     Be aware that this method does NOT return an instance for the default (unnamed)
            //     registration.
        
    
    public static IEnumerable<T> ResolveAll<T>(this IUnityContainer container, params ResolverOverride[] resolverOverrides);
    
     
            }
        }
