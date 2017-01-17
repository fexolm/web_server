using Webserver.Server.Parsers;
using WebServer.Server.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebServer.Server.Result;

namespace WebServer.Server.Connector
{
    static class MethodConnector
    {
        public static string Invoke(HttpRequest request)
        {
            if (request.IsFile)
            {
                return new BaseResult(request.Path, request.FileType).ToString();
            }
            if (request.Controller != null)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.Name.ToLower() == request.Controller.ToLower())
                    {
                        var methods = type.GetMethods();
                        foreach (var method in methods)
                        {
                            if (method.Name.ToLower() == request.Method.ToLower())
                            {
                                if (method.GetCustomAttribute<HttpMethodAttribute>().Method == request.HttpMethod)
                                    try
                                    {
                                        return InvokeMethod(type, method, request).ToString();
                                    }
                                    catch (Exception ex)
                                    {
                                        return new HttpResponse(false, 400, ex.ToString(), "text/html").ToString();
                                    }
                            }
                        }
                    }
                }
            }
            return new HttpResponse(false, 404, "Page not found", "text/html").ToString();
        }

        private static object InvokeMethod(Type type, MethodInfo method, HttpRequest request)
        {
            var parametersValues = new Json(request.EntityBody);
            var parametersVariables = method.GetParameters();
            int length = parametersVariables.Length;
            string[] parameters = new string[length];
            object[] result = new object[length];
            int i = 0;
            foreach (var parameter in parametersVariables)
            {
                parametersValues.variables.TryGetValue(parameter.Name, out parameters[i]);
                result[i] = Convert.ChangeType(parameters[i], parameter.ParameterType);
                i++;
            }
            return method.Invoke(type, result);
        }
    }
}
