Imports System.Net.Http
Imports System.Web.Http
Imports Microsoft.Owin.Security.OAuth
Imports Newtonsoft.Json.Serialization
Imports System.Net.Http.Headers

Public Module WebApiConfig
    Public Sub Register(config As HttpConfiguration)
        ' Configuración y servicios de Web API
        ' Configure Web API para usar solo la autenticación de token de portador.
        config.SuppressDefaultHostAuthentication()
        config.Filters.Add(New HostAuthenticationFilter(OAuthDefaults.AuthenticationType))

        ' Rutas de Web API
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
        'Para mostrar la salida de datos como JSON en vez de XML
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(New MediaTypeHeaderValue("text/html"))
    End Sub
End Module
