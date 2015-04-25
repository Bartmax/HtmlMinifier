using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System.IO;
using System.Threading.Tasks;
using ZetaHtmlCompressor;

namespace HtmlMinifier.MiddleWare
{
    public class HtmlMinifierMiddleWare
    {
        RequestDelegate _next;

        public HtmlMinifierMiddleWare(RequestDelegate next)
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
}
