    Contoso   <--- This is where you can put all your common code. I do not mean cross cutting concern here. By common I mean if you have some contstants or enums that are shared by all Dlls
    Contoso.Business
    Contoso.Api
    Contoso.WebApp
    Contoso.Data
    Contoso.Business.Tests // The name of test projects are exactly the same as the name of the assembly but has the word "Tests" at the end
    Contoso.Api.Tests
