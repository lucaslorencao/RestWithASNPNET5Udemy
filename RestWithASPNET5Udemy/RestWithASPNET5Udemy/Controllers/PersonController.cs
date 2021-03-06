using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5Udemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        { 

            return Ok(_personBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }





















        //[HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        //public IActionResult Subtraction(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        //public IActionResult Multiplication(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("division/{firstNumber}/{secondNumber}")]
        //public IActionResult Division(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("mean/{firstNumber}/{secondNumber}")]
        //public IActionResult Mean(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
        //        return Ok(sum.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("square-root/{firstNumber}")]
        //public IActionResult SquareRoot(string firstNumber)
        //{
        //    if (IsNumeric(firstNumber))
        //    {
        //        var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
        //        return Ok(squareRoot.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //private bool IsNumeric(string strNumber)
        //{
        //    double number;
        //    bool isNumber = double.TryParse(
        //        strNumber, 
        //        System.Globalization.NumberStyles.Any, 
        //        System.Globalization.NumberFormatInfo.InvariantInfo, 
        //        out number);

        //    return isNumber;
        //}

        //private decimal ConvertToDecimal(string strNumber)
        //{
        //    decimal decimalValue;
        //    if(decimal.TryParse(strNumber, out decimalValue))
        //    {
        //        return decimalValue;
        //    }

        //    return 0;
        //}


    }
}
