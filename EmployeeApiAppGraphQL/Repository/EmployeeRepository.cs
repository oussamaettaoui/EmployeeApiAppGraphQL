using EmployeeApiAppGraphQL.DbContextApp;
using EmployeeApiAppGraphQL.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApiAppGraphQL.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDBContext _context;
        public EmployeeRepository(AppDBContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.Include(e => e.Reviews).ToList();
        }
        public Employee? GetEmployeeById(int id)
        {
            return _context.Employees.Include(e => e.Reviews).FirstOrDefault(e => e.Id == id);
        }
        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }
        public Employee? UpdateEmployee(int id, Employee employee)
        {
            var _employee = _context.Employees.Where(d => d.Id == id).FirstOrDefault();
            if (_employee != null)
            {
                _employee.Email = employee.Email;
                _employee.FirstName = employee.FirstName;
                _employee.LastName = employee.LastName;
            }
            _context.SaveChanges();
            return _employee;
        }
        public void DeleteEmployee(int id)
        {
            var _employee = _context.Employees.Where(d => d.Id == id).FirstOrDefault();
            if (_employee != null)
            {
                _context.Employees.Remove(_employee);
                _context.SaveChanges();
            }
        }
    }
}
