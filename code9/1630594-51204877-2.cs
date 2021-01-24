    private static RuntimeMethodHandle GetDynamicMethodRuntimeHandle(DynamicMethod method) {
      RuntimeMethodHandle handle;
      if (Environment.Version.Major == 4) {
        handle = GetDynamicMethodRuntimeHandle(method.GetBaseDefinition());
      } else {
        var fieldInfo = typeof(DynamicMethod).GetField("m_method", BindingFlags.NonPublic | BindingFlags.Instance);
        handle = (RuntimeMethodHandle) fieldInfo.GetValue(method);
      }
      return handle;
    }
    private static RuntimeMethodHandle GetDynamicMethodRuntimeHandle(MethodBase method) {
      RuntimeMethodHandle handle;    
      if (Environment.Version.Major == 4) {
        var getMethodDescriptorInfo = typeof(DynamicMethod).GetMethod("GetMethodDescriptor", BindingFlags.NonPublic | BindingFlags.Instance);
        handle = (RuntimeMethodHandle) getMethodDescriptorInfo.Invoke(method, null);
      } else {
        var fieldInfo = typeof(DynamicMethod).GetField("m_method", BindingFlags.NonPublic | BindingFlags.Instance);
        handle = (RuntimeMethodHandle) fieldInfo.GetValue(method);
      }    
      return handle;
    }
