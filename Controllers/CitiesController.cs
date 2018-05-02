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
    public class CitiesController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Cities.ToListAsync());
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Cities.FirstOrDefaultAsync(b => b.Id == id));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Save([FromBody] CityViewModel city)
        {
            using (var context = new RedContext())
            {
                var newCity = context.Cities.Add(new City
                {
                    CountryId = city.CountryId,
                    DepartmentId = city.DepartmentId,
                    Name = city.CityName
                });

                await context.SaveChangesAsync();
                return Ok(new CityViewModel(newCity));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] CityViewModel city)
        {
            using (var context = new RedContext())
            {
                var ExistCity = await context.Cities.FirstOrDefaultAsync(b => b.Id == city.CityId);
                if (ExistCity == null)
                {
                    return NotFound();
                }

                ExistCity.CountryId = city.CountryId;
                ExistCity.DepartmentId = city.DepartmentId;
                ExistCity.Name = city.CityName;

                await context.SaveChangesAsync();
                return Ok(new CityViewModel(ExistCity));
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new RedContext())
            {
                var city = await context.Cities.FirstOrDefaultAsync(r => r.Id == id);
                if (city == null)
                {
                    return NotFound();
                }

                context.Cities.Remove(city);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
