# HtmlMinifier
Html minifier middleware for aspnet 5.

This middleware intercepts the Response.Body Stream and compress it using [Zeta Html Compressor]( http://blog.magerquark.de/c-port-of-googles-htmlcompressor-library/) if it's html.

Usage:

```
public void Configure(IApplicationBuilder app)
{
    app.UseHtmlMinifier();
    ...
}
```
