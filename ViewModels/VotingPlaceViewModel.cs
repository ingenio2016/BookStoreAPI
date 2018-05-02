using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.ViewModels
{
    public class VotingPlaceViewModel
    {
        public VotingPlaceViewModel()
        {
        }

        public VotingPlaceViewModel(VotingPlace votingplace)
        {
            if (votingplace == null)
            {
                return;
            }

            VotingPlaceId = votingplace.Id;
            CountryId = votingplace.CountryId;
            DepartmentId = votingplace.DepartmentId;
            CityId = votingplace.CityId;
            Name = votingplace.Name;
            Code = votingplace.Code;
        }

        public int VotingPlaceId { get; set; }
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public VotingPlace ToReview()
        {
            return new VotingPlace
            {
                Id = VotingPlaceId,
                Name = Name,
                CountryId = CountryId,
                DepartmentId = DepartmentId,
                CityId = CityId,
                Code = Code
            };
        }
    }
}