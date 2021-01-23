    Public Class Service1
        Inherits System.Web.Services.WebService
        <System.Web.Services.WebMethod(CacheDuration:=60)> _
        Public Function ConvertTemperature(ByVal dFahrenheit As Double) _
                                           As Double
            ConvertTemperature = ((dFahrenheit - 32) * 5) / 9
        End Function
    End Class
