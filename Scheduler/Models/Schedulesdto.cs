namespace Scheduler.Models
{
    public class Schedulesdto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public DateTime EndTime { get; set; }

        public string HalfDay { get; set; }

        public bool IsAllDay { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public string Imageurl { get; set; }

        public string Subject { get; set; }

        public string Username { get; set; }

        public string Rolename { get; set; }

        public int RoleId { get; set; }



    }
}
