using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Cw5.Services;

namespace Cw5.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IDbService service)
        {
            httpContext.Request.EnableBuffering();

            if (httpContext.Request != null)
            {
                string sciezka = httpContext.Request.Path; //"api.students"
                string querystring = httpContext.Request?.QueryString.ToString();
                string metoda = httpContext.Request.Method.ToString();
                string bodyStr = "";

                using (StreamReader reader
                 = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await reader.ReadToEndAsync();
                    httpContext.Request.Body.Position = 0;
                }

                //logowanie do pliku
                string[] lines = {sciezka, metoda, querystring, bodyStr };
                string writePath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                try
                {
                    System.IO.File.WriteAllLines(writePath + @"\WriteLines.txt", lines);
                }
                catch (Exception exc)
                {

                }
            }
            if (_next != null)
            {
                await _next(httpContext);
            }
        }
    }
}
