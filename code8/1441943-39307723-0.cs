    [System.Security.SecuritySafeCritical]  // auto-generated
            protected Delegate(Object target,String method)
            {
                if (target == null)
                    throw new ArgumentNullException("target");
                
                if (method == null)
                    throw new ArgumentNullException("method");
                Contract.EndContractBlock();
                
                // This API existed in v1/v1.1 and only expected to create closed
                // instance delegates. Constrain the call to BindToMethodName to
                // such and don't allow relaxed signature matching (which could make
                // the choice of target method ambiguous) for backwards
                // compatibility. The name matching was case sensitive and we
                // preserve that as well.
                if (!BindToMethodName(target, (RuntimeType)target.GetType(), method,
                                      DelegateBindingFlags.InstanceMethodOnly |
                                      DelegateBindingFlags.ClosedDelegateOnly))
                    throw new ArgumentException(Environment.GetResourceString("Arg_DlgtTargMeth"));
            }
                
            // This constructor is called from a class to generate a 
            // delegate based upon a static method name and the Type object
            // for the class defining the method.
            [System.Security.SecuritySafeCritical]  // auto-generated
            protected unsafe Delegate(Type target,String method)
            {
                if (target == null)
                    throw new ArgumentNullException("target");
     
                if (target.IsGenericType && target.ContainsGenericParameters)
                    throw new ArgumentException(Environment.GetResourceString("Arg_UnboundGenParam"), "target");
     
                if (method == null)
                    throw new ArgumentNullException("method");
                Contract.EndContractBlock();
     
                RuntimeType rtTarget = target as RuntimeType;
                if (rtTarget == null)
                    throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"), "target");
     
                // This API existed in v1/v1.1 and only expected to create open
                // static delegates. Constrain the call to BindToMethodName to such
                // and don't allow relaxed signature matching (which could make the
                // choice of target method ambiguous) for backwards compatibility.
                // The name matching was case insensitive (no idea why this is
                // different from the constructor above) and we preserve that as
                // well.
                BindToMethodName(null, rtTarget, method,
                                 DelegateBindingFlags.StaticMethodOnly |
                                 DelegateBindingFlags.OpenDelegateOnly |
                                 DelegateBindingFlags.CaselessMatching);
            }
