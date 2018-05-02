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
    public class DepartmentsController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Departments.ToListAsync());
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Departments.FirstOrDefaultAsync(b => b.Id == id));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Save([FromBody] DepartmentViewModel department)
        {
            using (var context = new RedContext())
            {
                var newDepartment = context.Departments.Add(new Department
                {
                    CountryId = department.CountryId,
                    Name = department.DepartmentName
                });

                await context.SaveChangesAsync();
                return Ok(new DepartmentViewModel(newDepartment));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] DepartmentViewModel department)
        {
            using (var context = new RedContext())
            {
                var ExistDepartment = await context.Departments.FirstOrDefaultAsync(b => b.Id == department.DepartmentId);
                if (ExistDepartment == null)
                {
                    return NotFound();
                }

                ExistDepartment.CountryId = department.CountryId;
                ExistDepartment.Name = department.DepartmentName;

                await context.SaveChangesAsync();
                return Ok(new DepartmentViewModel(ExistDepartment));
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new RedContext())
            {
                var department = await context.Departments.FirstOrDefaultAsync(r => r.Id == id);
                if (department == null)
                {
                    return NotFound();
                }

                context.Departments.Remove(department);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
