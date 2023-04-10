using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Entity
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string ShortenUrl { get; set; }
        public string OriginalUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ShortStringUrl { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
