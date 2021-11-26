using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Complaint_Management_System.Models.Entities
{
    public class ComplaintResponse
    {

        [Key]
        public int ResponseID { get; set; }


        [DisplayName("Respond")]
        [StringLength(800)]
        public string Reply_Description { get; set; }

        public int ComplaintID { get; set; }

        public string StaffID { get; set; }
    }


}
