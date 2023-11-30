using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_ApiCatalogo.Models
{ 
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto")]
        [Display(Name = "Descrição")]
        [StringLength(300)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [StringLength(50)]
        public decimal Price { get; set; }

        public float Stock { get; set; }
        public DateTime RegisterData { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
