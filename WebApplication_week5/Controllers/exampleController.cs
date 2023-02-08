using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_week5.Controllers
{
    public class exampleController : ApiController
    {
        /// <summary>
        /// Receive an input of the temperature and provides a message indicating the season
        /// </summary>
        /// <param name="temperature">The temperature in degree C</param>
        /// <example>Get api/example/seasion/21  -> "The season is Summer!"</example>
        /// <example>Get api/example/seasion/17  -> "The season is Fall!"</example>
        /// <example>Get api/example/seasion/-15  -> "The season is Winter!"</example>
        /// <returns>If temperatur is greater than 20, return "Summer!". If the temperature is greater than 15, return "Fall!".
        /// Else if the temperature is greater than 10, return "Spring!". Else return "Winter!"</returns>
        [HttpGet]
        [Route("api/example/Season/{temperature}")]
        public string Season(int temperature)
        {
            /*method 1
            if(temperature > 20)
            {
                return "Summer";
            }else if(temperature > 15)
            {
                return "Fall";
            }else if(temperature > 10)
            {
                return "Spring";
            }
            else
            {
                return "Winter";
            }
            */

            //Method 2(simplified)
            string season = "";
            if (temperature > 20)
            {
                season = "Summer";
            }
            else if (temperature > 15)
            {
                season = "Fall";
            }
            else if (temperature > 10)
            {
                season = "Spring";
            }
            else
            {
                season = "Winter";
            }
            string message = "The season is " + season + "!";
            return message;
        }


    }
}
