


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle.Models {
  public class MaintenanceRecord {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id {get; set;}
    public DateTime Date {get; set;}
    public decimal Cost {get; set;}
    public string Description {get; set;}
    public int CarId {get; set;}
    public Car car {get; set;}
  }
}