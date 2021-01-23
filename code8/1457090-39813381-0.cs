     [Fact]
            public void CreatePublicKeyParameters__ShouldReturnPublicKey__WhenPassPublicKeyBytes()
            {
    
                ApplePay applePay = new ApplePay(new MOBSHOPApplePayRequest());
                byte[] privateKey = Base64.Decode(
                    "MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEl/XAbOgrSCupps/QbIxJ3u4QZ1PlbO5uGDD1zj/JGMoephYSEgw+63gHQHekx3T8duXN3CoYafUpuQlwOeK6/w==");
                var publickey = applePay.CreatePublicKeyParameters(privateKey);
            }
