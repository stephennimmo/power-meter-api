using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerMeterApi.Models
{
    [Table("meter", Schema="dbo")]
    public class Meter
    {

        public Meter()
        {

        }

        public Meter(string meterId)
        {
            this.MeterId = meterId;
        }

        [Key]
        [Column("meter_id")]
        public string MeterId { get; set; }
        
        [Column("id_authority")]
        public string IdAuthority { get; set; }

        [Column("address_line_1")]
        public string AddressLine1 { get; set; }
        
        [Column("address_line_2")]
        public string AddressLine2 { get; set; }

        [Column("city")]
        public string City { get; set; }
        
        [Column("state")]
        public string State { get; set; }

        [Column("zip_code")]        
        public string ZipCode { get; set; }
    }
}