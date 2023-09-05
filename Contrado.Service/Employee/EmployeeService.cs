using AutoMapper;
using Contrado.Core.Entities;
using Contrado.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrado.Service.Employee
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IRepository<EmployeeEntity> _employeeRepository;
      
        public EmployeeService(     IRepository<EmployeeEntity> employeeRepository )
        {

            
            _employeeRepository = employeeRepository;


        }
        public async Task AddEmployee(EmployeeEntity employeeeViewModel)
        {
            await _employeeRepository.Insert(employeeeViewModel);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.Delete(id);
        }

        public async Task<EmployeeEntity> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<List<EmployeeEntity>> GetEmployees()
        {
            return  _employeeRepository.TableNoTracking.ToList();
        }

        public async Task UpdateEmployee(EmployeeEntity employeeeViewModel)
        {
            await _employeeRepository.Update(employeeeViewModel);
        }
    }
}
