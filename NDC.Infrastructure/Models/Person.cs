using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDC.Infrastructure.Models
{
    public class Person
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [DataType("datetime2")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(15)]
        public string Gender { get; set; }

        [Required]
        [Range(50, 250)]
        public int Height { get; set; }

        [Required]
        [Range(50, 150)]
        public double Weight { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

    }
}
