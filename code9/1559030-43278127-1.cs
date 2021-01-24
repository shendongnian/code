    namespace ConsoleApp1 {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Reflection;
        using ICSharpCode.Decompiler;
        using ICSharpCode.Decompiler.Ast;
        using ICSharpCode.NRefactory.CSharp;
        using Mono.Cecil;
        class Program {
            static void Main(string[] args) {
                var path = Assembly.GetExecutingAssembly().Location;
                var assembly = AssemblyDefinition.ReadAssembly(path);
                var types = assembly.Modules.SelectMany(x => x.Types).ToList();
                var baseType = types.FirstOrDefault(x => x.FullName == typeof(Command).FullName);
                var derivedTypes = types.Where(x => x.BaseType == baseType);
                var ctx = new DecompilerContext(assembly.MainModule);
                foreach (var type in derivedTypes) {
                    var astBuilder = new AstBuilder(ctx);
                    astBuilder.AddType(type);
                    var ast = astBuilder.SyntaxTree;
                    var ctorDecls = ast.Descendants.OfType<ConstructorDeclaration>();
                    var descriptors = ctorDecls.Select(ctor => Describe(type, ctor));
                    foreach (var desc in descriptors) {
                        var firstParameter = desc.BaseCallParameters.FirstOrDefault();
                        Console.WriteLine(desc.Signature);
                        Console.WriteLine($"If you use this {desc.Type.Name} constructor, then the first parameter to {baseType.Name}'s constructor will be {firstParameter}");
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                }
            }
            private static string GetPrettyCtorName(ConstructorDeclaration ctor) {
                var copy = ctor.Clone();
                var blocks = copy.Children.OfType<BlockStatement>().ToList();
                foreach (var block in blocks) {
                    block.Remove();
                }
                return copy.ToString().Replace(Environment.NewLine, "");
            }
            private static ConstructorDescriptor Describe(TypeDefinition type, ConstructorDeclaration ctor) {
                return new ConstructorDescriptor {
                    Type = type,
                    Signature = GetPrettyCtorName(ctor),
                    BaseCallParameters =
                                ctor
                                .Descendants
                                .OfType<MemberReferenceExpression>()
                                .Where(y => y.ToString() == "base..ctor")
                                .Select(y => y.Parent)
                                .FirstOrDefault()
                                ?.Children
                                .Skip(1)
                };
            }
        }
        public class ConstructorDescriptor {
            public TypeDefinition Type { get; set; }
            public string Signature { get; set; }
            public IEnumerable<AstNode> BaseCallParameters { get; set; }
        }
        public class Command {
            public Command(byte b1, byte b2, byte b3, byte[] data) { }
        }
        public class ReadVersionCommand : Command {
            public ReadVersionCommand() : base(0x13, 0x37, 0x48, null) { }
            public ReadVersionCommand(byte b2) : base(0x05, b2, 0x00, null) { }
            public ReadVersionCommand(byte b1, byte b2) : base(b1, b2, 0x00, null) { }
        }
    }
