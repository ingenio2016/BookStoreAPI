using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.ViewModels
{
    public class CommuneViewModel
    {
        public CommuneViewModel()
        {
        }

        public CommuneViewModel(Commune commune)
        {
            if (commune == null)
            {
                return;
            }

            CountryId = commune.CountryId;
            DepartmentId = commune.DepartmentId;
            CityId = commune.CityId;
            Name = commune.Name;
            CommuneId = commune.CommuneId;
        }

        public int CommuneId { get; set; }
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }

        public Commune ToReview()
        {
            return new Commune
            {
                CommuneId = CommuneId,
                Name = Name,
                CountryId = CountryId,
                DepartmentId = DepartmentId,
                CityId = CityId
            };
        }
    }
}