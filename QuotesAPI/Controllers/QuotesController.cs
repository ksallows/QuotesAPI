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
        public void Post([FromBody]Quote quote)
        {
            quotesDBContext.Quotes.Add(quote);
            quotesDBContext.SaveChanges(); //need this for changes to save to db...
        }

        // PUT: api/Quotes/5
        public void Put(int id, [FromBody]Quote quote)
        {
            // lambda expressions
            // (input-parameters) => expression
            // takes parameter q, and returns matches where the q.Id is the id given for update
            var entity = quotesDBContext.Quotes.FirstOrDefault(q => q.Id == id);
            entity.Title = quote.Title;
            entity.Description = quote.Description;
            entity.Author = quote.Author;
            quotesDBContext.SaveChanges();
        }

        // DELETE: api/Quotes/5
        public void Delete(int id)
        {
            var quote = quotesDBContext.Quotes.Find(id);
            quotesDBContext.Quotes.Remove(quote);
            quotesDBContext.SaveChanges();
        }
    }
}
