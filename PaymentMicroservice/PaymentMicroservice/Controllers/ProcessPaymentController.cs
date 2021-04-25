using Microsoft.AspNetCore.Mvc;
using PaymentMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPaymentController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProcessPaymentController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<ProcessPaymentController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ProcessPaymentController>/5
        [HttpGet]
        public ActionResult<double> GetBalance(string creditCardNumber, double creditLimit, double processingCharge)
        {
            
            try
            {
                double payment = _repository.GetBalance(creditCardNumber,creditLimit,processingCharge);
                return Ok(payment);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        


        // POST api/<ProcessPaymentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProcessPaymentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProcessPaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
