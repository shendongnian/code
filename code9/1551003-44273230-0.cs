    <Entry Text="{Binding RegistrationEmail}">
        <Entry.Behaviors>
             <connector:EmailValidatorBehavior 
                IsValid="{Binding Source={x:Reference Root}, 
                          Path=BindingContext.IsRegistrationEmailValid, Mode=OneWayToSource}"/>
        </Entry.Behaviors>        
    </Entry>
