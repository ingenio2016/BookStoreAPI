using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.ViewModels
{
    public class CityViewModel
    {
        public CityViewModel()
        {
        }

        public CityViewModel(City city)
        {
            if (city == null)
            {
                return;
            }

            CountryId = city.CountryId;
            DepartmentId = city.DepartmentId;
            CityId = city.Id;
            CityName = city.Name;
        }

        public int DepartmentId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }

        public City ToReview()
        {
            return new City
            {
                CountryId = CountryId,
                DepartmentId = DepartmentId,
                Id = CityId,
                Name = CityName
            };
        }
    }
}