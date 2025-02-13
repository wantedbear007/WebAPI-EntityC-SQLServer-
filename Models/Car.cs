

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle.Models
{
  public class Car
  {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int OwnerId { get; set; }
    public Owner owner { get; set; }
    public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
  }
}