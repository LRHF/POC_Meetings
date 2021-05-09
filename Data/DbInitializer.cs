using POC_Meetings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_Meetings.Data
{
    public class DbInitializer
    {
        public static void Initialize(MeetingsContext context)
        {
            if (context.Meetings.Any())
            {
                return;   // DB has been seeded
            }

            var meetings = new Meeting[]
            {
                new Meeting {ContactName="Bill Gates", CompanyName="Microsoft", Email="Bill.Gates@microsoft.com", MobileNumber=123456789, MeetingDate=DateTime.Parse("2021-01-01"), FollowUpDate=DateTime.Parse("2021-01-15"), FollowUpDone=true, MeetingNotes="Microsoft 1 Lorem ipsum dolor sit amet, consectetur adipiscing elit."},
                new Meeting {ContactName="Bill Gates", CompanyName="Microsoft", Email="Bill.Gates@microsoft.com", MobileNumber=123456789, MeetingDate=DateTime.Parse("2021-02-01"), FollowUpDate=DateTime.Parse("2021-02-15"), FollowUpDone=false,MeetingNotes="Microsoft 2 Lorem ipsum dolor sit amet, consectetur adipiscing elit."},
                new Meeting {ContactName="Satya Nadella", CompanyName="Microsoft", Email="Satya.Nadella@microsoft.com", MobileNumber=123456789, MeetingDate=DateTime.Parse("2021-03-01"), FollowUpDate=DateTime.Parse("2021-03-15"), FollowUpDone=false, MeetingNotes="Microsoft 3 Lorem ipsum dolor sit amet, consectetur adipiscing elit."},
                new Meeting {ContactName="Mark Zuckerberg", CompanyName="Facebook", Email="Mark.Zuckerberg@facebook.com", MobileNumber=123456789, MeetingDate=DateTime.Parse("2021-04-01"), FollowUpDate=DateTime.Parse("2021-04-15"), FollowUpDone=true, MeetingNotes="Facebook 1 Lorem ipsum dolor sit amet, consectetur adipiscing elit."}
            };

            context.Meetings.AddRange(meetings);
            context.SaveChanges();
        }

    }
}


