using EmployeeApiAppGraphQL.Model;
using EmployeeApiAppGraphQL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApiAppGraphQL.Controllers
{
    [Route("/EmployeeController")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public ActionResult<Employee> GetAll()
        {
            var allEmployees = _employeeRepository.GetAllEmployees();
            return Ok(allEmployees);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            var result = _employeeRepository.AddEmployee(employee);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEpmloyee(int id, [FromBody] Employee employee)
        {
            var updatedEmployee = _employeeRepository.UpdateEmployee(id, employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEpmloyee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return NoContent();
        }
    }
}
