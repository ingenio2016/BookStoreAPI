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
    public class VotingPlacesController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new RedContext())
            {
                return Ok(await context.VotingPlaces.ToListAsync());
            }
        }

        
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new RedContext())
            {
                return Ok(await context.VotingPlaces.Where(v => v.CityId == id).ToListAsync());
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Save([FromBody] VotingPlaceViewModel votingplace)
        {
            using (var context = new RedContext())
            {
                var newVotingPlace = context.VotingPlaces.Add(new VotingPlace
                {
                    Id = votingplace.VotingPlaceId,
                    Name = votingplace.Name,
                    CountryId = votingplace.CountryId,
                    DepartmentId = votingplace.DepartmentId,
                    CityId = votingplace.CityId,
                    Code = votingplace.Code
                });

                await context.SaveChangesAsync();
                return Ok(new VotingPlaceViewModel(newVotingPlace));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] VotingPlaceViewModel votingplace)
        {
            using (var context = new RedContext())
            {
                var ExistVotingPlace = await context.VotingPlaces.FirstOrDefaultAsync(b => b.Id == votingplace.VotingPlaceId);
                if (ExistVotingPlace == null)
                {
                    return NotFound();
                }

                ExistVotingPlace.Name = votingplace.Name;
                ExistVotingPlace.CountryId = votingplace.CountryId;
                ExistVotingPlace.DepartmentId = votingplace.DepartmentId;
                ExistVotingPlace.CityId = votingplace.CityId;
                ExistVotingPlace.Code = votingplace.Code;

                await context.SaveChangesAsync();
                return Ok(new VotingPlaceViewModel(ExistVotingPlace));
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new RedContext())
            {
                var votingplace = await context.VotingPlaces.FirstOrDefaultAsync(r => r.Id == id);
                if (votingplace == null)
                {
                    return NotFound();
                }

                context.VotingPlaces.Remove(votingplace);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
