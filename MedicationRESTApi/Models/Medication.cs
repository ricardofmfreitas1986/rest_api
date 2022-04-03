using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MedicationRESTApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Medication")]
    public class Medication
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; set; }

    }
}
