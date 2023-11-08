using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Entities;

[Table("Orders")]
public class Order
{
      public int OrderId { get; set; }            
      public DateTime OrderDate { get; set; }

      public virtual IEnumerable<LineItem> LineItems { get; set; }


}
