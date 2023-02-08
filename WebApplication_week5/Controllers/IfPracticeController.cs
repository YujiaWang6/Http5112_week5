using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_week5.Controllers
{
    public class IfPracticeController : ApiController
    {
        /// <summary>
        /// Claculate the total value of coins, return TRUE if Jenny can afford toy (costs 10.50), if not, reture FALSE
        /// </summary>
        /// <param name="nickles">The number of nickles</param>
        /// <param name="dimes">The number of dimes</param>
        /// <param name="quarters">The number of quarters</param>
        /// <param name="loonies">The number of loonies</param>
        /// <param name="twoonies">The number of twoonies</param>
        /// <example>eg. GET api/IfPractice/CoinComputer/0/0/0/15/0		-> TRUE</example>
        /// <example>eg.GET api/IfPractice/CoinComputer/20/0/0/1/1		-> FALSE</example>
        /// <example>eg.GET api/IfPractice/CoinComputer/100/20/2/4/0	-> TRUE</example>
        /// <returns>If total money can affort the 10.50 toy or not</returns>
        [HttpGet]
        [Route("api/IfPractice/CoinComputer/{nickles}/{dimes}/{quarters}/{loonies}/{twoonies}")]

        public bool CoinComputer(int nickles, int dimes, int quarters, int loonies, int twoonies)
        {
            decimal nicklesValue = 0.05m;
            decimal dimesValue = 0.10m;
            decimal quartersValue = 0.25m;
            decimal looniesValue = 1.00m;
            decimal twooniesValue = 2.00m;

            decimal totalCoin = nicklesValue * nickles + dimesValue * dimes + quartersValue * quarters + looniesValue * loonies + twooniesValue * twoonies;
            decimal toyPrice = 10.50m;
            if(totalCoin >= toyPrice)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }


        /// <summary>
        /// To see a given (x,y) in which quadrant
        /// </summary>
        /// <param name="x">the value of x in coordinate</param>
        /// <param name="y">the value of y in coordinate</param>
        /// <returns>The quadrant of (x,y) belongs to</returns>
        /// <example>eg. GET api/IfPractice/PointQuadrant/1/1	-> 	1</example>
        /// <example>eg. GET api/IfPractice/PointQuadrant/-1/-1	->	3</example>
        /// <example>eg. GET api/IfPractice/PointQuadrant/1/-1	->	4</example>
        /// <example>eg. GET api/IfPractice/PointQuadrant/0/10	->	0</example>

        [HttpGet]
        [Route("api/IfPractice/PointQuadrant/{x}/{y}")]
        public string PointQuadrant(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return "0";
            }
            else
            {
                if (x > 0 && y > 0)
                {
                    return "1";
                }
                else if (x < 0 && y > 0)
                {
                    return "2";
                }
                else if (x < 0 && y < 0)
                {
                    return "3";
                }
                else
                {
                    return "4";
                }
            }
        }


        /// <summary>
        /// The number of quadrants the line two points (x1,y1), (x2,y2) passes through 
        /// </summary>
        /// <param name="x1">the value of first point in x coordinate</param>
        /// <param name="y1">the value of first point in y coordinate</param>
        /// <param name="x2">the value of second point in x coordinate</param>
        /// <param name="y2">the value of second point in y coordinate</param>
        /// <returns>The number of quadrants the line passes through</returns>
        /// <example>eg. GET api/IfPractice/LineQuadrant/1/1/-1/-1		->	2</example>
        /// <example>eg. GET api/IfPractice/LineQuadrant/-10/5/10/5 	->	2</example>
        /// <example>eg. GET api/IfPractice/LineQuadrant/1/2/3/4		->	1</example>
        /// <example>eg. GET api/IfPractice/LineQuadrant/-4/35/4/35		->	2</example>
        /// <example>eg. GET api/IfPractice/LineQuadrant/10/0/-10/0		->	0</example>
        /// <example>eg. GET api/IfPractice/LineQuadrant/-6/-10/2/20	->	3</example>
        [HttpGet]
        [Route("api/IfPractice/LineQuadrant/{x1}/{y1}/{x2}/{y2}")]
        public int LineQuadrant(int x1, int y1, int x2, int y2)
        {
            //set quadrant variable
            int quadrant;
            //line y=ax+b
            //a = (y2 - y1) / (x2 - x1);
            //b = y1 - ((y2 - y1) / (x2 - x1)) * x1;


            //check when x1=x2 (a=infinity) -> vertical line
            if (x1 == x2)
            {
                if(y1==y2)
                {
                    quadrant = 0;
                }
                else if((y1<0 && y2>0) || (y1>0 && y2 < 0))
                {
                    quadrant = 2;
                }
                else 
                { 
                    quadrant = 1; 
                }

            }
            //check when a=0 (y=b) -> horizontal line
            else if ((y2 - y1) / (x2 - x1) == 0)
            {
                if(y1 - ((y2 - y1) / (x2 - x1)) * x1 == 0)
                {
                    quadrant = 0;
                }
                else
                {
                    if((x1>0 && x2<0) || (x1<0 && x2>0))
                    {
                        quadrant = 2;

                    }else
                    {
                        quadrant = 1;
                    }
                           
                }
            }
            //check when b=0 (y=ax) -> line pass through origin
            else if(y1 - ((y2 - y1) / (x2 - x1)) * x1 == 0)
            {
                if((x1>0 && x2<0) || (x1<0 && x2 >0))
                {
                    quadrant = 2;
                }
                else
                {
                    quadrant = 1;
                }
            }
            //a!=0 and b!=0  ->  y=ax+b
            else 
            {
                if((x1>0 && x2<0) || (x1<0 && x2 > 0))
                {
                    if(y1==0 || y2 == 0)
                    {
                        quadrant = 2;
                    }
                    else
                    {
                        quadrant = 3;
                    }
                }else if(x1>0 && x2 > 0)
                {
                    if((y1>0 && y2<0) || (y1<0 && y2 > 0))
                    {
                        quadrant = 2;
                    }
                    else
                    {
                        quadrant = 1;
                    }
                }
                else
                {
                    if((y1<0 && y2>0) || (y1>0 && y2 < 0))
                    {
                        quadrant = 2;
                    }
                    else
                    {
                        quadrant = 1;
                    }
                }
                
            }
            return quadrant;



            
        }



    }
}
