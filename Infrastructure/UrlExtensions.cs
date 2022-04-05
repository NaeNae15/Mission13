using System;
using Microsoft.AspNetCore.Http;

namespace MySQLApp.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuerey(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
