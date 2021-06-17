using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMvc.Models
{
    public class MovieCreateViewModel
    {
        [DisplayName("Titel")]
        [Required, MaxLength(50)]
        public string Title { get; set; }
        
        [DisplayName("Beschrijving")]
        [MaxLength(250)]
        public string Description { get; set; }
        [DisplayName("Genre")]

        public string Genre { get; set; }
    }
}
