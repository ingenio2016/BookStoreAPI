using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksAPI.Models
{
    public class RedUser
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}