using Contrado.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrado.Service.Employee
{
  public  interface IEmployeeService
    {
        Task UpdateEmployee(EmployeeEntity employeeeViewModel);
        Task AddEmployee(EmployeeEntity employeeeViewModel);
        Task<EmployeeEntity> GetEmployeeById(int id);
        
        Task<List<EmployeeEntity>> GetEmployees();
        Task DeleteEmployee(int id );


    }
}
