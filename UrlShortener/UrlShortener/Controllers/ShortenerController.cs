using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UrlShortener.Models;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    public class ShortenerController : Controller
    {
        private readonly ILogger<ShortenerController> _logger;
        private readonly IShortener _service;

        public ShortenerController(ILogger<ShortenerController> logger, IShortener service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet("ShortenUrlAutomaticly")]
        public async Task<string> ShortenUrlAutomaticly(string originalUrl)
        {
            return await _service.GenerateUrl(originalUrl);
        }
        [HttpGet("ShortenUrlCustomly")]
        public async Task<string> ShortenUrlAutomaticly(CustomUrlModel customUrlModel)
        {
            return await _service.GenerateUrl(customUrlModel);
        }
        [HttpGet("r")]
        public async Task<IActionResult> Index(string u)
        {
            var redirectUrl = await _service.RedirectUrl(u);
            return Redirect(redirectUrl);

        }
    }
}
