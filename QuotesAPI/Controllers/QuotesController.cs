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

        [HttpGet]
        [Route("api/Quotes/All/{sort=asc}")]
        public IHttpActionResult GetQuotes(string sort)
        {
            IQueryable<Quote> quotes;
            switch (sort)
            {
                case "desc":
                    quotes = quotesDBContext.Quotes.OrderByDescending(q => q.CreatedAt);
                    break;
                case "asc":
                    quotes = quotesDBContext.Quotes.OrderBy(q => q.CreatedAt);
                    break;
                default:
                    quotes = quotesDBContext.Quotes;
                    break;
            }
            return Ok(quotes);
        }

        [HttpGet]
        [Route("api/Quotes/page/{pageNumber=1}/{pageSize=5}")]
        public IHttpActionResult Pagination(int pageNumber, int pageSize)
        {
            var quotes = quotesDBContext.Quotes.OrderBy(q => q.Id);
            return Ok(quotes.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        [HttpGet]
        [Route("api/Quotes/Quote/{id=}")]
        public IHttpActionResult GetQuote(int id)
        {
            var quote = quotesDBContext.Quotes.Find(id);
            if (quote == null) return NotFound();
            return Ok(quote);
        }

        [HttpGet]
        [Route("api/Quotes/Search/{type=}")]
        public IHttpActionResult Search(string type)
        {
            var quotes = quotesDBContext.Quotes.Where(q => q.Type.StartsWith(type));
            return Ok(quotes);
        }

        public IHttpActionResult Post([FromBody]Quote quote)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            quotesDBContext.Quotes.Add(quote);
            quotesDBContext.SaveChanges(); //need this for changes to save to db...
            return StatusCode(HttpStatusCode.Created);
        }

        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            // lambda expressions
            // (input-parameters) => expression
            // takes parameter q, and returns matches where the q.Id is the id given for update
            var existingQuote = quotesDBContext.Quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null) return BadRequest("Not found");
            existingQuote.Title = quote.Title;
            existingQuote.Description = quote.Description;
            existingQuote.Author = quote.Author;
            quotesDBContext.SaveChanges();
            return Ok("Quote updated");
        }


        public IHttpActionResult Delete(int id)
        {
            var quote = quotesDBContext.Quotes.Find(id);
            if (quote == null) return BadRequest("Not found");
            quotesDBContext.Quotes.Remove(quote);
            quotesDBContext.SaveChanges();
            return Ok("Quote deleted");
        }
    }
}
