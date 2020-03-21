using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    
    [ApiController]
    public class ValuesController : ControllerBase
    {
            
        [Route("info")]
        public ActionResult<string> Info()
        {
            return "nums/{num}\r\nequations?a=1&b=4&c=-1\r\ndayOfWeek?date=12.12.2028\r\nfibonacci/{index}\r\ngetRegion/{num}";
        }

        [Route("nums/{num}")]
        public ActionResult<string> NumToString(int num)
        {
            return RusNumber.Str(num);
        }

        [Route("equations")]
        [HttpGet]
        public string[] Equations(int a,int b, int c)
        {
            return EquationSolver.Get(a,b,c);
        }

        [Route("dayOfWeek")]
        public ActionResult<string>  GetDayOfWeek(string date)
        {
            var splitted = date.Split(".").Select(str => int.Parse(str)).ToArray();
            return new DateTime(splitted[2], splitted[1], splitted[0]).DayOfWeek.ToString();
        }

        [Route("fibonacci/{index}")]
        public ActionResult<string> GetFibValue(int index)
        {
            return GetFibonacciNumber.Get(index).ToString();
        }

        [Route("getRegion/{num}")]
        public ActionResult<string> GetRegionByNum(int num)
        {
            return Regions.Get(num).ToString();
        }

    }
}
