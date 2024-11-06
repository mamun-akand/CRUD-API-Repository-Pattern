using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatient _patientrepo;
        public PatientController(IPatient ptnt)
        {
            _patientrepo = ptnt;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var x = _patientrepo.GetAllPatients();
            if (x == null)
            {
                return NotFound();
            }
            return Ok(x);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            Patient p = _patientrepo.GetPatientByID(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        [Route("Creates")]
        public IActionResult Creates(Patient pt)
        {
            var rs = _patientrepo.CreatePatient(pt);
            if(rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
            {
                return Ok("Added! " + rs);
            }
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit(Patient pt)
        {
            int rs = _patientrepo.UpdatePatient(pt);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
            {
                return Ok("Updated " + rs);
            }
        }

        [HttpDelete]
        [Route ("Delete")]
        public IActionResult Delete(int id)
        {
            int rs = _patientrepo.DeletePatient(id);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
            {
                return Ok("Deleted " + rs);
            }
        }     
    }
}
