    <system.web>
      <caching>
          <outputCache defaultProvider="HeaderModOutputCacheProvider">
            <providers>
              <add name="HeaderModOutputCacheProvider" type="CustomOutputCache.HeaderModOutputCacheProvider"/>
            </providers>
          </outputCache>
        </caching>
      </system.web>
