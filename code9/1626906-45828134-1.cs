    nuget install Microsoft.Net.Compilers   # Install C# and VB compilers
    nuget install Microsoft.CodeAnalysis    # Install Language APIs and Services
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Emit;
