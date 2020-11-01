using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Deadline //not sure 
    {
        public string days { get; set; } //should be readonly //testing
        public TimeSpan timespan { get; set; } //should be reaonly //testing

        public static Deadline week1 = new Deadline("14 days", new TimeSpan(14, 0, 0, 0)); //set a static deadline field 
        public static List<Deadline> deadlines = new List<Deadline>() { week1 }; //add it to the list of deadlines (to be populated later)
        
        public Deadline(string days,TimeSpan timespan) 
        {
            this.days = days;
            this.timespan = timespan;
        }
        public static DateTime setDeadline(DateTime reportedDate,TimeSpan timespan) //set deadline of timespan 14 days 
        {
            if(timespan.Days == 14)
            {
                return reportedDate.AddDays(14);
            }
            return reportedDate;
        }
    }
}
