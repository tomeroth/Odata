using Library;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace WebApi.Controllers
{
    public class GamesController : ODataController
    {
            GamesContext db = new GamesContext();

            [EnableQuery]
            public IQueryable<Game> Get()
            {
                return db.Games;
            }

            [EnableQuery]
            public SingleResult<Game> Get([FromODataUri] int key)
            {
                IQueryable<Game> result = db.Games.Where(p => p.Id == key);
                return SingleResult.Create(result);
            }

            public async Task<IHttpActionResult> Post(Game game)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                db.Games.Add(game);
                await db.SaveChangesAsync();
                return Created(game);
            }

            public async Task<IHttpActionResult> Put([FromODataUri] int id, Game update)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != update.Id)
                {
                    return BadRequest();
                }
                db.Entry(update).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Updated(update);
            }

            public async Task<IHttpActionResult> Delete([FromODataUri] int key)
            {
                var product = await db.Games.FindAsync(key);
                if (product == null)
                {
                    return NotFound();
                }
                db.Games.Remove(product);
                await db.SaveChangesAsync();
                return StatusCode(HttpStatusCode.NoContent);
            }


            private bool GameExists(int key)
            {
                return db.Games.Any(p => p.Id == key);
            }
            protected override void Dispose(bool disposing)
            {
                db.Dispose();
                base.Dispose(disposing);
            }
    }
}
