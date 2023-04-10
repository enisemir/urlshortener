using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Entity;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public interface IShortener
    {
        Task<string> GenerateUrl(string originalUrl);
        Task<string> GenerateUrl(CustomUrlModel customUrlModel);
        Task<string> RedirectUrl(string u);
    }
}
