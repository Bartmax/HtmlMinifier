using System.IO;
using System.Threading.Tasks;
using ZetaHtmlCompressor;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Builder;

namespace HtmlMinifier
{
    public class HtmlMinifierMiddleware
    {
        private readonly RequestDelegate _next;

        public HtmlMinifierMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            using (var memoryStream = new MemoryStream())
            {
                var bodyStream = context.Response.Body;
                context.Response.Body = memoryStream;

                await _next(context);

                var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
                if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
                {
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        using (var streamReader = new StreamReader(memoryStream))
                        {
                            string body = await streamReader.ReadToEndAsync();
                            body = MinifyHtml(body);
                            using (var minBodyStream = new MemoryStream())
                            using (var streamWriter = new StreamWriter(minBodyStream))
                            {
                                streamWriter.Write(body);
                                streamWriter.Flush();
                                minBodyStream.Seek(0, SeekOrigin.Begin);
                                await minBodyStream.CopyToAsync(bodyStream);
                            }
                        }
                    }
                }
            }
        }

        private static string MinifyHtml(string responseBody)
        {
            var compressor = new HtmlContentCompressor();
            return compressor.Compress(responseBody);
        }
    }
    public static class StaticFileExtensions
    {
        public static IApplicationBuilder UseHtmlMinifier(this IApplicationBuilder app) 
            => app.UseMiddleware<HtmlMinifierMiddleware>();
    }
}
