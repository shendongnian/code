    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Scripty.Core;
    using System.Linq;
    using System.Threading.Tasks;
    
    bool IsInternalOrPublicSetter( AccessorDeclarationSyntax a )
    {
        return a.Kind() == SyntaxKind.SetAccessorDeclaration &&
            a.Modifiers.Any( m => m.Kind() == SyntaxKind.PublicKeyword || m.Kind() == SyntaxKind.InternalKeyword );
    }
    
    
    foreach( var document in Context.Project.Analysis.Documents )
    {
        // Get all partial classes that inherit from IIsUpdatable
        var allClasses = (await document.GetSyntaxRootAsync())
                        .DescendantNodes().OfType<ClassDeclarationSyntax>()
                        .Where( cls => cls.BaseList?.ChildNodes()?.SelectMany( _ => _.ChildNodes()?.OfType<IdentifierNameSyntax>() ).Select( id => id.Identifier.Text ).Contains( "IIsUpdatable" ) ?? false)
                        .Where( cls => cls.Modifiers.Any( m => m.ValueText == "partial" ))
                        .ToList();
    
    
        foreach( var cls in allClasses )
        {
            var curFile = $"{cls.Identifier}Exprs.cs";
            Output[curFile].WriteLine( $@"using System;
    using System.Linq.Expressions;
    
    namespace SomeNS
    {{
        public partial class {cls.Identifier}
        {{" );
            // Get all properties with public or internal setter
            var props = cls.Members.OfType<PropertyDeclarationSyntax>().Where( prop => prop.AccessorList.Accessors.Any( IsInternalOrPublicSetter ) );
            foreach( var prop in props )
            {
                Output[curFile].WriteLine( $"        public static Expression<Func<{cls.Identifier},object>> {prop.Identifier}Expr = _ => _.{prop.Identifier};" );
            }
    
            Output[curFile].WriteLine( @"    }
    }" );
        }
    
    }
