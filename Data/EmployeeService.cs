using Blazor_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Blazor_API.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeService : Controller
    {
        #region Property
        private readonly AppDBContext _appDBContext;
        #endregion

        #region Constructor
        public EmployeeService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Employees
        [Route("GetAllEmployeesAsync")]
        [HttpGet]
        [SwaggerOperation(Summary = "GetBookingDetailsByID - Returns bookings per ID", Description = "Returns true if successful ")]
        public async Task<List<EmployeeDepartment>> GetAllEmployeesAsync()
        {
            string query = @"SELECT 
                                Id, DName, EmployeName, City
                             FROM TritonFleetManagement.dbo.Employee E 
                             INNER JOIN TritonFleetManagement.dbo.Department D ON D.EmployeeID = E.Id";

            //return await _appDBContext.Employee.ToListAsync();
            var studentList = await _appDBContext.EmployeeDepartment.FromSqlRaw(query).ToListAsync<EmployeeDepartment>();
            return studentList;
        }
        #endregion

        //#region Insert Employee
        //public async Task<bool> InsertEmployeeAsync(Employee employee)
        //{
        //    await _appDBContext.Employees.AddAsync(employee);
        //    await _appDBContext.SaveChangesAsync();
        //    return true;
        //}
        //#endregion

        //#region Get Employee by Id
        //public async Task<Employee> GetEmployeeAsync(int Id)
        //{
        //    Employee employee = await _appDBContext.Employees.FirstOrDefaultAsync(c => c.Id.Equals(Id));
        //    return employee;
        //}
        //#endregion

        //#region Update Employee
        //public async Task<bool> UpdateEmployeeAsync(Employee employee)
        //{
        //    _appDBContext.Employees.Update(employee);
        //    await _appDBContext.SaveChangesAsync();
        //    return true;
        //}
        //#endregion

        //#region DeleteEmployee
        //public async Task<bool> DeleteEmployeeAsync(Employee employee)
        //{
        //    _appDBContext.Remove(employee);
        //    await _appDBContext.SaveChangesAsync();
        //    return true;
        //}
        //#endregion
    }
}
