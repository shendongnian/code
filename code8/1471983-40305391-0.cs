        [Pure]
        private void VerifyWritable() {
            if (isReadOnly) {
                throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
            }
            Contract.EndContractBlock();
        }
