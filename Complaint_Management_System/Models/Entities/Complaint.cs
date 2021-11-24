using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Complaint_Management_System.Models.Entities
{
    public class Complaint
    {
        [Key]
        public int ComplaintID { get; set; }

        [Required]
        [DisplayName("New Complaint")]
        [StringLength(800)]
        public string Description { get; set; }

        public int StudentID { get; set; }

    }
}
