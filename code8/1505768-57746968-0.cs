C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
namespace Platform.Reflection
{
    public static class DelegateHelpers
    {
        public static TDelegate CompileOrDefault<TDelegate>(Action<ILGenerator> emitCode)
            where TDelegate : Delegate
        {
            var @delegate = default(TDelegate);
            try
            {
                var delegateType = typeof(TDelegate);
                var invoke = delegateType.GetMethod("Invoke");
                var returnType = invoke.ReturnType;
                var parameterTypes = invoke.GetParameters().Select(s => s.ParameterType).ToArray();
                var dynamicMethod = new DynamicMethod(Guid.NewGuid().ToString(), returnType, parameterTypes);
                var generator = dynamicMethod.GetILGenerator();
                emitCode(generator);
                @delegate = (TDelegate)dynamicMethod.CreateDelegate(delegateType);
            }
            catch (Exception exception)
            {
                // ignore
            }
            return @delegate;
        }
    }
}
Or, you can just reference [Platform.Reflection](https://www.nuget.org/packages/Platform.Reflection) NuGet package. And use Platform.Reflection.DelegateHelpers.
