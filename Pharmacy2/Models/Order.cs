using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy2.Models
{
    public class Order
    {
        public string? Id { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal total { get; set; }
        public string? drugNames { get; set; }


    }
}
