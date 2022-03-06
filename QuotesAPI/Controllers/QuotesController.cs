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
        public IHttpActionResult Get()
        {
            var quotes = quotesDBContext.Quotes;
            //return StatusCode(quotes);
            return Ok(quotes);
        }

        // GET: api/Quotes/5
        public IHttpActionResult Get(int id)
        {
            var quote = quotesDBContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        // POST: api/Quotes
        public IHttpActionResult Post([FromBody]Quote quote)
        {
            quotesDBContext.Quotes.Add(quote);
            quotesDBContext.SaveChanges(); //need this for changes to save to db...
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Quotes/5
        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            // lambda expressions
            // (input-parameters) => expression
            // takes parameter q, and returns matches where the q.Id is the id given for update
            var existingQuote = quotesDBContext.Quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null)
            {
                return BadRequest("Not found");
            }
            existingQuote.Title = quote.Title;
            existingQuote.Description = quote.Description;
            existingQuote.Author = quote.Author;
            quotesDBContext.SaveChanges();
            return Ok("Quote updated");
        }

        // DELETE: api/Quotes/5
        public IHttpActionResult Delete(int id)
        {
            var quote = quotesDBContext.Quotes.Find(id);
            if (quote == null)
            {
                return BadRequest("Not found");
            }
            quotesDBContext.Quotes.Remove(quote);
            quotesDBContext.SaveChanges();
            return Ok("Quote deleted");
        }
    }
}
