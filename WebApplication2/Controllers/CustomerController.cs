using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebApplication2.Contracts;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.UnitOfWork;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitofwork<AppDbContext> _unitofwork  ;
        //private IGenericRepository<Customer> _genericRepository;
        private ICustomerRepository _customerRepository;
        public CustomerController(
            //IGenericRepository<Customer> genericRepository,
            IUnitofwork<AppDbContext> unitofwork,
            ICustomerRepository customerRepository)
        {
            //_genericRepository = genericRepository;
            _unitofwork = unitofwork;
            _customerRepository = customerRepository;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetById(id);
            return Ok(customer);
        }


        [HttpGet("CustomerByName")]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            var custs = await _customerRepository.GetCustomerByName(name);
            return Ok(custs);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            
           var result1 = _unitofwork.Repository<Customer>().AddAsync(customer);
            _unitofwork.Commit();
            var id = customer.Id;
            return Ok(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customer = await _customerRepository.GetAll(); //_genericRepository.GetAll();
            return customer.ToList();
        }


    }
}
