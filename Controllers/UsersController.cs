using BooksAPI.Core;
using BooksAPI.Models;
using BooksAPI.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class UsersController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Usuarios.ToListAsync());
            }
        }


        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new RedContext())
            {
                return Ok(await context.Usuarios.FirstOrDefaultAsync(b => b.Id == id));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Save([FromBody] UsuarioViewModel usuario)
        {
            using (var context = new RedContext())
            {
                var newUsuario = context.Usuarios.Add(new User
                {
                    Id = usuario.Id,
                    Address = usuario.Address,
                    CityId = usuario.CityId,
                    DepartmentId = usuario.DepartmentId,
                    CountryId = usuario.CountryId,
                    FirstName = usuario.FirstName,
                    Genero = usuario.Genero,
                    LastName = usuario.LastName,
                    Phone = usuario.Phone,
                    Photo = usuario.Photo,
                    UserName = usuario.UserName,
                    Password = usuario.Password
                });

                var role = context.Roles.First(c => c.Name == "User").Id;

                var User = context.Users.Add(new IdentityUser("usuario") { Email = newUsuario.UserName, EmailConfirmed = true });
                User.Roles.Add(new IdentityUserRole { RoleId = role });

                await context.SaveChangesAsync();

                var store = new RedUserStore();
                await store.SetPasswordHashAsync(User, new RedUserManager().PasswordHasher.HashPassword(usuario.Password));
                return Ok(new UsuarioViewModel(newUsuario));
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody] UsuarioViewModel usuario)
        {
            using (var context = new RedContext())
            {
                var ExistUsuario = await context.Usuarios.FirstOrDefaultAsync(b => b.Id == usuario.Id);
                if (ExistUsuario == null)
                {
                    return NotFound();
                }

                ExistUsuario.Address = usuario.Address;
                ExistUsuario.CityId = usuario.CityId;
                ExistUsuario.DepartmentId = usuario.DepartmentId;
                ExistUsuario.CountryId = usuario.CountryId;
                ExistUsuario.FirstName = usuario.FirstName;
                ExistUsuario.Genero = usuario.Genero;
                ExistUsuario.LastName = usuario.LastName;
                ExistUsuario.Phone = usuario.Phone;
                ExistUsuario.Photo = usuario.Photo;
                ExistUsuario.UserName = usuario.UserName;
                ExistUsuario.Password = usuario.Password;

                await context.SaveChangesAsync();
                return Ok(new UsuarioViewModel(ExistUsuario));
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new RedContext())
            {
                var usuario = await context.Usuarios.FirstOrDefaultAsync(r => r.Id == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                context.Usuarios.Remove(usuario);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
