        <system.serviceModel>
            <services>
                <service name="WcfService1.MyService">
                    <endpoint binding="basicHttpBinding"
                           bindingConfiguration="" contract="WcfService1.IMyService" 
                        BehaviorConfiguration="MyServiceBehaviors" />
                 </service>
             </services>
        </system.serviceModel>
    
        <behaviors>
             <serviceBehaviors>
                 <behavior name="MyServiceBehaviors" >
                     <serviceMetadata httpGetEnabled="true" />
                 </behavior>
             </serviceBehaviors>
        </behaviors>
