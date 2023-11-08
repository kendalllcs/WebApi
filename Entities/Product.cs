using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Entities;

[Table("Products")]
public class Product
{
      [Key]
      public int ProductId { get; set; }
      [MaxLength(50)]

      
      public string? ProductName { get; set; }

      public float Price { get; set; }

      public virtual IEnumerable<Ingredient> Ingredients { get; set; } = null!;


      
}
