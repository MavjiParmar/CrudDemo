using Contrado.Core.Entities;
using Contrado.Service.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contrado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.GetEmployees();

            return Ok(employees);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employees = await _employeeService.GetEmployeeById(id);

            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmployeeEntity employee)
        {
            await _employeeService.UpdateEmployee(employee);           
            return Ok("Employee updated successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeEntity employee)
        {
            await _employeeService.AddEmployee(employee);
            return Ok("Employee created successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok("Employee deleted successfully.");
        }
    }
}
