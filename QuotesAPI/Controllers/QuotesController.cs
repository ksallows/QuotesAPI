using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuotesAPI.Models;

namespace QuotesAPI.Controllers
{
    public class QuotesController : ApiController
    {
        static List<Quote> _quotes = new List<Quote>()
        {
            new Quote()
            {
                Id = 0,
                Author = "Einstein",
                Description = "Imagination is more important than knowledge.",
                Title = "Imagination"
            },
            new Quote()
            {
                Id = 1,
                Author = "Einstein",
                Description = "Imagination is more important than knowledge.",
                Title = "Imagination"
            }
        };

        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }

        public void Post([FromBody] Quote quote)
        {
            _quotes.Add(quote);
        }

        public void Put(int id, [FromBody] Quote quote)
        {
            //list _quotes index id will be set to the quote argument
            _quotes[id] = quote;
        }
    }
}
