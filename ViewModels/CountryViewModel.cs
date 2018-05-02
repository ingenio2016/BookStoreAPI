using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.ViewModels
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
        }

        public CountryViewModel(Country country)
        {
            if (country == null)
            {
                return;
            }

            CountryId = country.Id;
            CountryName = country.Name;

        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public Country ToReview()
        {
            return new Country
            {
                Id = CountryId,
                Name = CountryName
            };
        }
    }    
}