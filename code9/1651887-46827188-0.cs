    if (isAsync)
                {
                    var result = webInvocation.Invoke(_client, invocation.Arguments);
                    var type = result.GetType();
                    var methodInfo = typeof(Task).GetMethod("FromResult");
                    var genericMethod = methodInfo.MakeGenericMethod(type);
                    invocation.ReturnValue = genericMethod.Invoke(result, new []{ result });
                }
