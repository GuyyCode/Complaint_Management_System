using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Complaint_Management_System.Models.Enum
{
    public enum Faculty
    {
        [Description("Accounting And Informatics")]
        AccountingAndInformatics = 0,
        [Description("Applied Sciences")]
        AppliedSciences = 1,
        [Description("Arts And Design")]
        ArtsAndDesign = 2,
        [Description("Engineering And Built Environment")]
        EngineeringAndBuiltEnvironment = 3,
        [Description("Health Sciences")]
        HealthSciences = 5,
        [Description("Management Sciences")]
        ManagementSciences = 6,
        None = 7
    }
}
