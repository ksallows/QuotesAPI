using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QuotesAPI.Models;

namespace QuotesAPI.Data
{
    public class QuotesDBContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }

    }
}