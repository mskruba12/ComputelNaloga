using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputelNaloga.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ShortName { get; set; }

        public CarPurpose Purpose { get; set; }

        public string VehicleMake { get; set; }

        public string License { get; set; }

        public int TrackerDeviceId { get; set; }

        public string Description { get; set; }
    }
}
