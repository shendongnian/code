				    signCert.Verify(anchor.GetPublicKey());
				    LOGGER.Info("Certificate verified against root store");
				    result.Add(new VerificationOK(signCert, this, "Certificate verified against root store."));
                    // vvv remove
				    result.AddRange(base.Verify(signCert, issuerCert, signDate));
                    // ^^^ remove
				    return result;
