using BooksAPI.Core;
using BooksAPI.Models;
using BooksAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BooksAPI.Controllers
{
    public class CommunesController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Communes.ToListAsync());
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Communes.FirstOrDefaultAsync(b => b.CommuneId == id));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Save([FromBody] CommuneViewModel commune)
        {
            using (var context = new RedContext())
            {
                var newCommune = context.Communes.Add(new Commune
                {
                    CommuneId = commune.CommuneId,
                    Name = commune.Name,
                    CountryId = commune.CountryId,
                    DepartmentId = commune.DepartmentId,
                    CityId = commune.CityId
                });

                await context.SaveChangesAsync();
                return Ok(new CommuneViewModel(newCommune));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] CommuneViewModel commune)
        {
            using (var context = new RedContext())
            {
                var ExistCommune = await context.Communes.FirstOrDefaultAsync(b => b.CommuneId == commune.CommuneId);
                if (ExistCommune == null)
                {
                    return NotFound();
                }

                ExistCommune.Name = commune.Name;
                ExistCommune.CountryId = commune.CountryId;
                ExistCommune.DepartmentId = commune.DepartmentId;
                ExistCommune.CityId = commune.CityId;

                await context.SaveChangesAsync();
                return Ok(new CommuneViewModel(ExistCommune));
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new RedContext())
            {
                var commune = await context.Communes.FirstOrDefaultAsync(r => r.CommuneId == id);
                if (commune == null)
                {
                    return NotFound();
                }

                context.Communes.Remove(commune);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
