using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Data;
using Scheduler.Models;

namespace Scheduler.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly SchedulerContext _context;

        private readonly SchedulerContext _users;
        
        public SchedulesController(SchedulerContext context, SchedulerContext users)
        {
            _context = context;
            _users = users;
        }

        // GET: api/Schedules
        [HttpGet]

        public async Task<ActionResult<List<Schedulesdto>>> GetSchedule()
        {


            try
            {
                var schedules = (from sch in _context.Schedule
                                 join us in _context.Users
                                 on sch.EmployeeId equals us.Id
                                 join rl in _context.Roles
                                 on us.RoleId equals rl.Id


                                 select new Schedulesdto
                                 {
                                     Id = sch.Id,
                                     Description = sch.Description,
                                     UserId = sch.EmployeeId,
                                     EndTime = sch.EndTime,
                                     HalfDay = sch.HalfDay,
                                     IsAllDay = sch.IsAllDay,
                                     Location = sch.Location,
                                     StartTime = sch.StartTime,
                                     Imageurl = us.ImageUrl,
                                     Subject = sch.Subject,
                                     Username = us.Name,
                                     Rolename = rl.Name,
                                     RoleId = rl.Id

                                 });


                return schedules.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(int id)
        {
            var schedule = await _context.Schedule.FindAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;
        }



        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> PutSchedule(Schedule schedule)
        {
            try
            {
                _context.Entry(schedule).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return NoContent();
            
        }

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("sched")]
        public async Task<IAsyncResult> PostSchedule(Schedule schedule)
        {


            _context.Schedule.Add(new Schedule()
            {   
                //Id = schedule.Id,
                StartTime = schedule.StartTime.AddHours(5.5),
                EndTime = schedule.EndTime.AddHours(5.5),
                IsAllDay = schedule.IsAllDay,
                Subject = schedule.Subject,
                Description = schedule.Description,
                Location = schedule.Location,
                HalfDay = schedule.HalfDay,
                EmployeeId = schedule.EmployeeId
                              


            });

            await _context.SaveChangesAsync();

            return null;
            
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
    


    #region Users

    [HttpGet]
    [Route("GetUsers")]
    public async Task<List<Usersdto>> GetAllUsers()
    {
            var x = from Users us in _context.Users
                    join Roles rl in _context.Roles
                    on us.RoleId equals rl.Id

                    select new Usersdto
                    {
                        Id = us.Id,
                        Username = us.Name,
                        RoleId = us.RoleId,
                        Imageurl = us.ImageUrl,
                        Rolename = rl.Name


                    };


        return x.ToList();



    }

    #endregion
}

}

