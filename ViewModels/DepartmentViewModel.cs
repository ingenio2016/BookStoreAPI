using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.ViewModels
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
        }

        public DepartmentViewModel(Department department)
        {
            if (department == null)
            {
                return;
            }

            CountryId = department.CountryId;
            DepartmentId = department.Id;
            DepartmentName = department.Name;

        }

        public int DepartmentId { get; set; }
        public int CountryId { get; set; }
        public string DepartmentName { get; set; }

        public Department ToReview()
        {
            return new Department
            {
                CountryId = CountryId,
                Id = DepartmentId,
                Name = DepartmentName
            };
        }
    }
}