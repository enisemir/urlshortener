using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Entity;
using UrlShortener.Models;

namespace UrlShortener.Services.Impls
{
    public class Shortener:IShortener
    {
        private readonly Context _context;
        private readonly string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        private readonly string _baseUrl = "http://localhost:37890/r?u=";
        public Shortener(Context context)
        {
            _context = context;
        }
        public async Task<string> GenerateUrl(string originalUrl)
        {
            if (string.IsNullOrEmpty(originalUrl))
            {
                throw new Exception($"originalUrl is not valid.");
            }
            var random = new Random();
            var shortStringUrl = new string(
                Enumerable.Repeat(chars, 6)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            ShortUrl shortUrl = new ShortUrl();
            shortUrl.IsActive = true;
            shortUrl.IsDeleted = false;
            shortUrl.CreationTime = DateTime.Now;
            shortUrl.OriginalUrl = originalUrl;
            shortUrl.ShortStringUrl = shortStringUrl;
            shortUrl.ShortenUrl = string.Concat(_baseUrl, shortStringUrl);

            await _context.ShortUrl.AddAsync(shortUrl);
            await _context.SaveChangesAsync();
            return shortUrl.ShortenUrl;
        }
        public async Task<string> RedirectUrl(string u)
        {
            var original = new ShortUrl();
            if (!string.IsNullOrEmpty(u))
            {
                original = _context.ShortUrl.FirstOrDefault(x => x.ShortStringUrl == u);
            }
            if (string.IsNullOrEmpty(u) || original == null)
            {
                throw new Exception($"not found");
            }
            return original.OriginalUrl;
        }
        public async Task<string> GenerateUrl(CustomUrlModel customUrlModel)
        {
            if (_context.ShortUrl.FirstOrDefault(x=>x.ShortStringUrl==customUrlModel.CustomUrl) != null)
            {
                throw new Exception($"already exist");
            }
            ShortUrl shortUrl = new ShortUrl();
            shortUrl.IsActive = true;
            shortUrl.IsDeleted = false;
            shortUrl.CreationTime = DateTime.Now;
            shortUrl.OriginalUrl = customUrlModel.OriginalUrl;
            shortUrl.ShortStringUrl = customUrlModel.CustomUrl;
            shortUrl.ShortenUrl = string.Concat(_baseUrl, customUrlModel.CustomUrl);

            await _context.ShortUrl.AddAsync(shortUrl);
            await _context.SaveChangesAsync();
            return shortUrl.ShortenUrl;
        }
    }
}
