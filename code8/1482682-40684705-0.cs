            if (string.IsNullOrWhiteSpace(sessionKey) || sessionKey.Length != SessionKeyLength)
            {
                // No valid cookie, new session.
                var guidBytes = new byte[16];
                CryptoRandom.GetBytes(guidBytes);
                sessionKey = new Guid(guidBytes).ToString();
                cookieValue = CookieProtection.Protect(_dataProtector, sessionKey);
                var establisher = new SessionEstablisher(context, cookieValue, _options);
                tryEstablishSession = establisher.TryEstablishSession;
                isNewSessionKey = true;
            }
