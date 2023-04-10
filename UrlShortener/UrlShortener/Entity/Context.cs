﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Entity
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<ShortUrl> ShortUrl { get; set; }
    }
}
