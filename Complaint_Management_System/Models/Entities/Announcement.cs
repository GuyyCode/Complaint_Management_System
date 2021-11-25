using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Complaint_Management_System.Models.Entities
{
    public class Announcement
    {
        [Key]
        public int AnnouncementID { get; set; }

        [Required]
        [DisplayName("New Announcement")]
        [StringLength(800)]
        public string Announcement_Description { get; set; }
        public DateTime Announcement_Date { get; set; }
        public string StaffID { get; set; }
        public int FacultyID { get; set; }

    }
}
