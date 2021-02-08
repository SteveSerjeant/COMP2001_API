using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2001_API.Models;
using Microsoft.Data.SqlClient;

namespace COMP2001_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectUsersController : ControllerBase
    {
        private readonly COMP2001_SSerjeantContext _context;

        public ProjectUsersController(COMP2001_SSerjeantContext context)
        {
            _context = context;
        }


        // GET: api/ProjectUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectUser>>> GetProjectUsers()
        {
            return await _context.ProjectUsers.ToListAsync();
        }
//      Attemp at code for method - cause load error
//        [HttpGet]
//       public IActionResult RegisterUser(string User_FirstName, string User_Surname, string User_Email, string User_Password)
//      {
//            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC RegisterUser @First_Name, @Surname, @email, @Password",
//           new SqlParameter("@First_Name", User_FirstName.ToString()),
//            new SqlParameter("@Surname", User_Surname.ToString()),
//            new SqlParameter("@email", User_Email.ToString()),
//           new SqlParameter("@Password", User_Password.ToString()));
//
//           return Ok();
//
 //       }
        // GET: api/ProjectUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectUser>> GetProjectUser(int id)
        {
            var projectUser = await _context.ProjectUsers.FindAsync(id);

            if (projectUser == null)
            {
                return NotFound();
            }

            return projectUser;
        }


        // PUT: api/ProjectUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectUser(int id, ProjectUser projectUser)
        {
            if (id != projectUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(projectUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectUser>> PostProjectUser(ProjectUser projectUser)
        {
            _context.ProjectUsers.Add(projectUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectUser", new { id = projectUser.UserId }, projectUser);
        }

        // DELETE: api/ProjectUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectUser(int id)
        {
            var projectUser = await _context.ProjectUsers.FindAsync(id);
            if (projectUser == null)
            {
                return NotFound();
            }

            _context.ProjectUsers.Remove(projectUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectUserExists(int id)
        {
            return _context.ProjectUsers.Any(e => e.UserId == id);
        }
    }
}
