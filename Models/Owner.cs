

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle.Models {
  public class Owner {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id {get; set;}
    public string Name {get; set;}
    public string Address {get; set;}
    public ICollection<Car> cars {set; get;}
  }
}