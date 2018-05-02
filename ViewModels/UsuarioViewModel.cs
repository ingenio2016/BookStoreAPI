using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
        }

        public UsuarioViewModel(User user)
        {
            if (user == null)
            {
                return;
            }

            Id = user.Id;
            CountryId = user.CountryId;
            DepartmentId = user.DepartmentId;
            CityId = user.CityId;
            Address = user.Address;
            FirstName = user.FirstName;
            Genero = user.Genero;
            LastName = user.LastName;
            Phone = user.Phone;
            Photo = user.Photo;
            UserName = user.UserName;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Genero { get; set; }
        public string Photo { get; set; }
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int CityId { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public string Password { get; set; }

        public User ToReview()
        {
            return new User
            {
                Id = Id,
                CountryId = CountryId,
                DepartmentId = DepartmentId,
                CityId = CityId,
                Address = Address,
                FirstName = FirstName,
                Genero = Genero,
                LastName = LastName,
                Phone = Phone,
                Photo = Photo,
                UserName = UserName
            };
        }
    }
}