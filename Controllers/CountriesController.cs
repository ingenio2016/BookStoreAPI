using BooksAPI.Core;
using BooksAPI.Models;
using BooksAPI.ViewModels;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace BooksAPI.Controllers
{
    public class CountriesController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Countries.ToListAsync());
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Countries.FirstOrDefaultAsync(b => b.Id == id));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Save([FromBody] CountryViewModel country)
        {
            using (var context = new RedContext())
            {
                var newCountry = context.Countries.Add(new Country
                {
                    Id = country.CountryId,
                    Name = country.CountryName
                });

                await context.SaveChangesAsync();
                return Ok(new CountryViewModel(newCountry));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] CountryViewModel country)
        {
            using (var context = new RedContext())
            {
                var Existcountry = await context.Countries.FirstOrDefaultAsync(b => b.Id == country.CountryId);
                if (Existcountry == null)
                {
                    return NotFound();
                }

                Existcountry.Name = country.CountryName;

                await context.SaveChangesAsync();
                return Ok(new CountryViewModel(Existcountry));
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new RedContext())
            {
                var country = await context.Countries.FirstOrDefaultAsync(r => r.Id == id);
                if (country == null)
                {
                    return NotFound();
                }

                context.Countries.Remove(country);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
