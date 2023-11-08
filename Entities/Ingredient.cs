
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Entities;

[Table("Ingredients")]
public class Ingredient
{

      public int IngredientId {get; set;}
      [MaxLength(50)]
      public string IngredientName {get; set;} = null!;

      public virtual IEnumerable<Product> Products { get; set; } = null!;

      
}
