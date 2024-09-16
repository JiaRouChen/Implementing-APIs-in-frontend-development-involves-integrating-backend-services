using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.DTO;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("apiStudent")]
    [ApiController]
    public class tStudentsController : ControllerBase
    {
        private readonly dbStudentsContext _context;

        public tStudentsController(dbStudentsContext context)
        {
            _context = context;
        }

        // GET: api/tStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tStudentDTO>>> GettStudents(string deptID)
        {
            var result = _context.tStudent.Where(s => s.DeptID == deptID).Select(s => new tStudentDTO
            {
                fStuId = s.fStuId,
                fName = s.fName,
                fEmail = s.fEmail == null ? "" : s.fEmail
            });

            //var result = _context.tStudent.Where(s => s.DeptID == deptID)
            //    .Join(_context.Department,
            //      s => s.DeptID,
            //      d => d.DeptID,
            //      (s, d) => new tStudentDTO
            //      {

            //          fStuId = s.fStuId,
            //          fName = s.fName,
            //          fEmail = s.fEmail == null ? "" : s.fEmail,
            //          DeptID = s.DeptID,
            //          DeptName = d.DeptName
            //      });


            //return Ok(await result.ToListAsync());
            return await result.ToListAsync();
        }

        // GET: api/tStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GettStudent(string id)
        {
            //var tStudent = await _context.tStudent.FindAsync(id);

            var tStudent = _context.tStudent.Where(s=>s.fStuId==id)
             .Join(_context.Department,
               s => s.DeptID,
               d => d.DeptID,
               (s, d) => new {
                   s.fStuId,
                   s.fName,
                   s.fEmail,
                   s.fScore,
                   s.DeptID,
                   d.DeptName
               });


            if (tStudent == null)
            {
                return NotFound();
            }

            return await tStudent.FirstOrDefaultAsync();
        }

        // PUT: api/tStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttStudent(string id, tStudent tStudent)
        {
            if (id != tStudent.fStuId)
            {
                return BadRequest();
            }

            _context.Entry(tStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tStudentExists(id))
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

        // POST: api/tStudents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tStudent>> PosttStudent(tStudent tStudent)
        {
            _context.tStudent.Add(tStudent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tStudentExists(tStudent.fStuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GettStudent", new { id = tStudent.fStuId }, tStudent);
        }

        // DELETE: api/tStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetStudent(string id)
        {
            var tStudent = await _context.tStudent.FindAsync(id);
            if (tStudent == null)
            {
                return NotFound();
            }

            _context.tStudent.Remove(tStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tStudentExists(string id)
        {
            return _context.tStudent.Any(e => e.fStuId == id);
        }
    }
}
