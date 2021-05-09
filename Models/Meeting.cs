using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace POC_Meetings.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Required, StringLength(100), Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, Display(Name = "Mobile Number")]
        public long MobileNumber { get; set; }

        [Display(Name = "Meeting Date"),  DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }

        [Display(Name = "Follow-Up Date"), DataType(DataType.Date), GreaterThan("MeetingDate")]
        public DateTime FollowUpDate { get; set; }

        [Display(Name = "Follow-Up Done")]
        public Boolean FollowUpDone { get; set; }

        [Required, StringLength(255), Display(Name = "Meeting Notes")]
        public string MeetingNotes { get; set; }

    }

    public class GreaterThan : ValidationAttribute
    {
        public string MeetingDate { get; private set; }

        public GreaterThan (string mettingDate)
        {
            MeetingDate = mettingDate ?? throw new ArgumentNullException(nameof(mettingDate));
        }

        protected override ValidationResult IsValid(object followUpDate, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(MeetingDate);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult("MettingDate is null");
            }

            object meetingDateValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if ((DateTime)followUpDate <= (DateTime)meetingDateValue)
            {
                return new ValidationResult("Follow-up must be greater than Meeting Date");
            }
            return null;
        }
       
    }

}


