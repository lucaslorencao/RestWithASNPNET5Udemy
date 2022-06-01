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
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        { 

            return Ok(_bookBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindByID(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
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
