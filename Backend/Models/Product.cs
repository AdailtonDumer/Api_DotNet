using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "Nome suporta até 50 caracteres.")]
        [Required(ErrorMessage = "Nome é de preenchimento obrigatório")]
        public string Name { get; set; }
        
        [Display(Name = "Valor")]
        public decimal? Price { get; set; }
    }
}