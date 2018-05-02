using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(250, ErrorMessage = "El campo {0} debe tener mínimo {1} caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener mínimo {1} caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener mínimo {1} caracteres")]
        public string LastName { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} debe tener mínimo {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [MaxLength(300, ErrorMessage = "El campo {0} debe tener mínimo {1} caracteres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Genero { get; set; }


        [DataType(DataType.ImageUrl)]
        [Display(Name = "Foto")]

        public string Photo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar {0}")]
        public int CountryId { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar {0}")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar {0}")]
        public int CityId { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; set; }
    }
}