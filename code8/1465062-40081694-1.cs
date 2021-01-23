    <system.identityModel>
      <identityConfiguration>
        ...
        <certificateValidation certificateValidationMode="PeerOrChainTrust" />
        <issuerNameRegistry type="System.IdentityModel.Tokens.ValidatingIssuerNameRegistry, System.IdentityModel.Tokens.ValidatingIssuerNameRegistry">
          <authority name="http://your-adfs-domain.com/adfs/services/trust">
            <keys>
              <add thumbprint="the thumbprint" />
            </keys>
            <validIssuers>
              <add name="http://your-adfs-domain.com/adfs/services/trust" />
            </validIssuers>
          </authority>
        </issuerNameRegistry>
      </identityConfiguration>
    </system.identityModel>
