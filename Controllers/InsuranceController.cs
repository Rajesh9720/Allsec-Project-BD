using Microsoft.AspNetCore.Mvc;
using EmpFD.Models;
namespace EmpFD.Controllers;


[ApiController]
[Route("Api/controller")]
public class InsuranceController : ControllerBase
{
    private readonly EmpInsuContext DB;
    
    public InsuranceController(EmpInsuContext db)
    {
        this.DB=db;
    }

        
        [HttpPost("InsertNominee")]
        public object InsertEmployee(InsuRegister regObj)
        {
            try
            {
                EmployeeInsu e1 = new EmployeeInsu();
                if (e1.EmployeeCode==0)
                {
                    e1.NomineeName=regObj.RegNomineeName;
                    e1.NomineeType=regObj.RegNomineeType;
                    e1.NomineeDob =regObj.RegNomineeDob;            
                    e1.NomineeAge=regObj.RegNomineeAge;
                    e1.InsurenceNo=regObj.RegInsurenceNo;
                    e1.Premium=regObj.RegPremium;
                    DB.EmployeeInsus.Add(e1);
                    DB.SaveChanges();

                    return new Response{Status="Success",Message="Add!!!!"};
                }

            }
            catch(System.Exception)
            {
                throw;
            }
            return new Response{Status="Error",Message="Invalid Information"};
        }
        

        [HttpGet("EmployeeInsurance")]
        public IQueryable<EmployeeInsu> GetAll()
        {
        var users =this.DB.EmployeeInsus;
        return users;
        }
        [HttpDelete("DeleteEmpDetails/{EmployeeCode}")]
    public IActionResult DeleteUser(int EmployeeCode)
    {
        string message = "";
            var user = this.DB.EmployeeInsus.Find(EmployeeCode);
            if (user == null)
            {
                return NotFound();
            }

            this.DB.EmployeeInsus.Remove(user);
            int result = this.DB.SaveChanges();
            if (result > 0)
            {
                message = "User has been sussfully deleted";
            }
            else
            {
                message = "failed";
            }

            return Ok(message);
        }

    }

