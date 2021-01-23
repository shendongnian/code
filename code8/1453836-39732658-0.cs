            OperationContext ocx = OperationContext.Current;
            using (new OperationContextScope(OperationContext.Current))
            {
                OperationContext.Current = new OperationContext(ocx.Channel);
                // ...
            }
