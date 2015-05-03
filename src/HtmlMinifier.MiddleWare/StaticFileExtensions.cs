using HtmlMinifier;
using System;

namespace Microsoft.AspNet.Builder
{
    public static class StaticFileExtensions
    {
        public static IApplicationBuilder UseHtmlMinifier(this IApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.UseMiddleware<HtmlMinifierMiddleware>();
            return builder;
        }
    }
}
