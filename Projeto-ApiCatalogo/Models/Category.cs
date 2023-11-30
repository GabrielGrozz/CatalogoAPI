using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_ApiCatalogo.Models
{
    [Table("Categories")]
    public class Category
    {
        public Category() 
        {
            Products = new Collection<Product>();
        }
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        [StringLength(300)]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
