using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scheduler.Models
{
    public class Schedule
    {
        //up[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsAllDay { get; set; }

        public string HalfDay { get; set; }
        public int EmployeeId{ get; set; }


        //public string RecurrenceRule { get; set; }

        //public int RecurrenceID { get; set;}

        //public string RecurrenceException { get; set; }


    }
}
