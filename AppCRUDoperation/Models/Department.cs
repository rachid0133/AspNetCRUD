

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCRUDoperation.Models
{
    [Table("Departements", Schema ="HR")]
    public class Department
    {
        [Key]
        [Display(Name = "ID")]
        public int DepartementId { get; set; }

        [Required]
        [Display(Name = "Departement Name")]
        [Column(TypeName = "varchar(200)")]
        public string DepartementName { get; set; } = string.Empty;
    }
}
