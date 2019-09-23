﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BloodBankAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodBankAPI.Controllers
{

    

    [Route("api/[controller]/[action]")]
    public class BloodBankController : Controller
    {
        private BloodBankContext _context;

        public BloodBankController(BloodBankContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<BloodDB>>> GetPatients()
        {
            return await _context.BloodDB.ToListAsync();
        }

        [HttpGet("{ID}")]
        [ActionName("GetWithID")]
        public async Task<ActionResult<BloodDB>> GetPatient(Guid id)
        {
            var patient = await _context.BloodDB.FindAsync(id);
            if(patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        [HttpGet("{NHSNumber}")]
        [ActionName("GetWithNHSNumber")]
        public Task<List<BloodDB>> GetPatientWithNHS(long NHSNumber)
        {
         
            SqlParameter NHSParam = new SqlParameter()
            {
                ParameterName ="@NHSNumber",
                Value = NHSNumber
            };
            var patient =  _context.BloodDB.FromSql("SELECT * FROM dbo.BloodDB WHERE NHSNumber =@NHSNumber",NHSParam).ToListAsync();

            Console.WriteLine(patient);
           

            return patient;
        }

        [HttpPost]
        [ActionName("InsertNewPatient")]
        public async Task<ActionResult<IEnumerable<BloodDB>>> AddPatient([FromBody]BloodDB patient)
        {
           
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            try
            {
                _context.BloodDB.Add(patient);

                await _context.SaveChangesAsync();
                //new { id = patient.id, Name = patient.Name, Age = patient.Age, donor = patient.donor, address = patient.address, phoneNumber = patient.phoneNumber, bloodType = patient.bloodType, NHSNumber = patient.NHSNumber }
                //return CreatedAtAction(nameof(GetPatients), new { id = patient.id, Name = patient.Name, Age = patient.Age, donor = patient.donor, address = patient.address, phoneNumber = patient.phoneNumber, bloodType = patient.bloodType, NHSNumber = patient.NHSNumber });
                return Ok("Successfully added " + patient.Name);
            } catch (Exception e)
            {
                return BadRequest("Invalid Data");
            }
            
        }

     //   [HttpPost]
      //  [ActionName("UpdatePatient")]
      //  public async Task<ActionResult<IEnumerable<BloodDB>>> UpdatePatient([FromBody]BloodDB patient)
      //  {
      //      _context.BloodDB.Update(patient);
//
        //    return;
   //     }
    }
}
