using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Models.Entities
{
    [Table("customer")]
    public class CustomerEntity
    {
        [Key]
        [Column("customer_id")]
        public long CustomerId { get; set; }

        [Column("login_id")]
        public long LoginId { get; set; }

        [Column("customer_name")]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [Column("mobile_no")]
        [StringLength(50)]
        public string MobileNo { get; set; }

    }
}
