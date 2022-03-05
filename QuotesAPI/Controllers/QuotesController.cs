using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuotesAPI.Data;
using QuotesAPI.Models;

namespace QuotesAPI.Controllers
{
    public class QuotesController : ApiController
    {
        QuotesDBContext quotesDBContext = new QuotesDBContext();
        // GET: api/Quotes
        public IEnumerable<Quote> Get()
        {
            return quotesDBContext.Quotes;
        }

        // GET: api/Quotes/5
        public Quote Get(int id)
        {
            var quote = quotesDBContext.Quotes.Find(id);
            return quote;
        }

        // POST: api/Quotes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Quotes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Quotes/5
        public void Delete(int id)
        {
        }
    }
}
