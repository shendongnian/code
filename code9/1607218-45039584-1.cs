      <system.web.extensions>
        <scripting>
          <webServices>
            <jsonSerialization maxJsonLength="2147483644">
              <converters>
                <add name="DateTimeConverter" type="DateTimeJsonSerializer,AssemblyNameGoesHere" />
              </converters>
            </jsonSerialization>
          </webServices>
        </scripting>
      </system.web.extensions>
