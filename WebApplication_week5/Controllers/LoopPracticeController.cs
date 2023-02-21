using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_week5.Controllers
{
    public class LoopPracticeController : ApiController
    {
        /// <summary>
        /// Return the counting numbers accourding the input
        /// </summary>
        /// <param name="start">start from what number</param>
        /// <param name="limit">until what numebr</param>
        /// <param name="step">the number of increament/decreament for each step</param>
        /// <returns>A list of string with the number</returns>
        /// <example>api/LoopPractice/Counter/0/4/1		->	[0,1,2,3,4]</example>
        /// <example>api/LoopPractice/Counter/-10/30/10		->	[-10,0,10,20,30]</example>
        /// <example>api/LoopPractice/Counter/-10/-17/2		->	[0]</example>
        /// <example>api/LoopPractice/Counter/-10/-17/-2		->	[-10,-12,-14,-16]</example>
        [HttpGet]
        [Route("api/LoopPractice/Counter/{start}/{limit}/{step}")]
        
        public string Counter(int start, int limit, int step)
        {
            string message = "";
            if (step > 0)
            {
                while (start <= limit)
                {
                    message = message + start.ToString() + ",";
                    start = start + step;
                }
            }
            else
            {
                while (start >= limit)
                {
                    message = message + start.ToString() + ",";
                    start = start + step;
                }
            }

            if (message == "")
            {
                message = message + "0";
            }
            return message;
        }

        /// <summary>
        /// Return the counting numbers accourding the input
        /// </summary>
        /// <param name="start">start from what number</param>
        /// <param name="limit">until what numebr</param>
        /// <param name="step">the number of increament/decreament for each step</param>
        /// <returns>A array with the number</returns>
        /// <example>api/LoopPractice/Counter/0/4/1		->	[0,1,2,3,4]</example>
        /// <example>api/LoopPractice/Counter/-10/30/10		->	[-10,0,10,20,30]</example>
        /// <example>api/LoopPractice/Counter/-10/-17/2		->	[0]</example>
        /// <example>api/LoopPractice/Counter/-10/-17/-2		->	[-10,-12,-14,-16]</example>
        [HttpGet]
        [Route("api/LoopPractice/Counter1/{start}/{limit}/{step}")]
        public IEnumerable<int> Counter1(int start, int limit, int step)
        {
            List<int> count = new List<int>();

            bool isIncreasing = (start < limit) && (step > 0);
            bool isDecreasing = (start > limit) && (step < 0);

            if(!isIncreasing && !isDecreasing) 
            {
                count.Add(0);
            }
            else if(isIncreasing)
            {
                for(int i = start; i <= limit; i = i + step)
                {
                    count.Add(i);
                }
            }
            else
            {
                for(int i = start; i>=limit; i = i + step)
                {
                    count.Add(i);
                }
            }
            return count;

        }


        /// <summary>
        /// outputs: a string which counts from {start} to {limit} counting by {step} In addition:
        /// - numbers divisible by {Fizzy} are replaced with "Fizzy"
        /// - numbers divisible by {Buzzy} are replaced with "Buzzy"
        /// - numbers divisible by {Fizzy} and {Buzzy} are replaced with "FizzyBuzzy"
        /// </summary>
        /// <param name="start">The start number</param>
        /// <param name="limit">The limit, can be upper limit or lower limit</param>
        /// <param name="step">Changes for each step</param>
        /// <param name="Fizzy">The fizzy number</param>
        /// <param name="Buzzy">The buzzy number</param>
        /// <returns>        
        /// outputs: a string which counts from {start} to {limit} counting by {step} In addition:
        /// - numbers divisible by {Fizzy} are replaced with "Fizzy"
        /// - numbers divisible by {Buzzy} are replaced with "Buzzy"
        /// - numbers divisible by {Fizzy} and {Buzzy} are replaced with "FizzyBuzzy"
        /// </returns>
        /// <example>api/LoopPractice/FizzyBuzzy/1/25/4/3/7  -> "1,5,Fizzy,13,17,FizzyBuzzy,25"</example>
        /// <example>api/LoopPractice/FizzyBuzzy/1/4/1/1/4   -> "Fizzy, Fizzy, Fizzy, FizzyBuzzy"</example>
        /// <example>api/LoopPractice/FizzyBuzzy/2/15/4/3/4  -> "2,Fizzy,10,14"</example>
        /// <example>api/LoopPractice/FizzyBuzzy/10/60/12/200/200  ->"10,22,34,46,58"</example>
        /// <example>api/LoopPractice/FizzyBuzzy/-40/-20/3/-2/-5  ->"FizzyBuzzy,-37,Fizzy,-31,Fizzy,Buzzy,Fizzy"</example>
        [HttpGet]
        [Route("api/LoopPractice/FizzyBuzzy/{start}/{limit}/{step}/{Fizzy}/{Buzzy}")]

        public string FizzyBuzzy(int start, int limit, int step, int Fizzy, int Buzzy)
        {
            string message = "";
            bool isIncreasing = (start < limit) && (step > 0);
            bool isDecreasing = (start > limit) && (step < 0);
            int i = start;

            if (!isIncreasing && !isDecreasing)
            {
                message = message + 0;
            }else if (isIncreasing)
            {
                while(i <= limit)
                {
                    if(i%Fizzy ==0 && i%Buzzy == 0)
                    {
                        message = message + "FizzyBuzzy";
                    }
                    else if(i % Fizzy == 0)
                    {
                        message = message + "Fizzy";
                    }else if(i % Buzzy ==0)
                    {
                        message = message + "Fizzy"; 
                    }
                    else
                    {
                        message = message + i;
                    }
                    message = message + ",";
                    i = i + step;
                }
            }
            else
            {
                while (i >= limit)
                {
                    if (i % Fizzy == 0 && i % Buzzy == 0)
                    {
                        message = message + "FizzyBuzzy";
                    }
                    else if (i % Fizzy == 0)
                    {
                        message = message + "Fizzy";
                    }
                    else if (i % Buzzy == 0)
                    {
                        message = message + "Fizzy";
                    }
                    else
                    {
                        message = message + i;
                    }

                    message = message + ",";
                    i = i + step;
                }

            }
            message = message.TrimEnd(message[message.Length -1]);
            return message;
        }

        /// <summary>
        /// Describe the minimum number of bills and coins needed to achieve the {amount}
        /// </summary>
        /// <param name="amount">The input should be the value * 100 (e.g 30250 = $302.50)</param>
        /// <returns>The minimum of bills and coins of the input amount</returns>
        /// <example>GET: api/LoopPractice/GetChange/10023   -> "Twenties : 5", Dimes : 2 , Pennies : 3"</example>
        /// <example>GET: api/LoopPractice/GetChange/1368   -> "Tens: 1, Toonies: 1, Loonies: 1, Quarters: 2, Dimes: 1, Nickels: 1, Penniess: 3 "</example>
        [HttpGet]
        [Route("api/LoopPractice/GetChange/{amount}")]
        public string GetChange(int amount)
        {
            int count = 0;
            int[] moneyValueInt = { 2000, 1000, 500, 200, 100, 25, 10, 5, 1 };
            int[] counts = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            string[] message = { "Twenties: ", "Tens: ", "Fives: ", "Toonies: ", "Loonies: ", "Quarters: ", "Dimes: ", "Nickels: ", "Penniess: " };
            string outputMessage = "";

            for (int i = 0; i < moneyValueInt.Length; i++)
            {
                count = amount / moneyValueInt[i];
                amount = amount - moneyValueInt[i] * count;
                counts[i] = count;
            }

            string delimiter = ", ";
            int j = 0;
            while (j < message.Length)
            {
                if (counts[j] > 0)
                {
                    if (j == message.Length - 1)
                    {
                        delimiter = " ";
                    }
                    outputMessage = outputMessage + message[j] + counts[j] + delimiter;
                }

                j++;
            }

            return outputMessage;
        }




        /// <summary>
        /// Outputs all squares on a chess board starting from A1, ending with H8. 
        /// Also determines which cells are light and which cells are dark.
        /// </summary>
        /// <returns>
        /// GET: api/LoopPractice/ChessBoard  ->
        /// "(A1:dark),(B1:light),(C1:dark),(D1:light),(E1:dark),(F1:light),(G1:dark),(H1:light),
        /// (A2:light),(B2:dark),(C2:light),(D2:dark),(E2:light),(F2:dark),(G2:light),(H2:dark),
        /// (A3:dark),(B3:light),(C3:dark),(D3:light),(E3:dark),(F3:light),(G3:dark),(H3:light),
        /// (A4:light),(B4:dark),(C4:light),(D4:dark),(E4:light),(F4:dark),(G4:light),(H4:dark),
        /// (A5:dark),(B5:light),(C5:dark),(D5:light),(E5:dark),(F5:light),(G5:dark),(H5:light),
        /// (A6:light),(B6:dark),(C6:light),(D6:dark),(E6:light),(F6:dark),(G6:light),(H6:dark),
        /// (A7:dark),(B7:light),(C7:dark),(D7:light),(E7:dark),(F7:light),(G7:dark),(H7:light),
        /// (A8:light),(B8:dark),(C8:light),(D8:dark),(E8:light),(F8:dark),(G8:light),(H8:dark)"
        /// </returns>
        [HttpGet]
        [Route("api/LoopPractice/ChessBoard")]

        public string ChessBoard()
        {
            string message = "";
            string[] rowInString = {"1", "2", "3", "4" ,"5"  };
            string[] columnInString = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int row = 1;
            int clo = 1;
            while(row <= 8)
            {
                clo = 1;
                while (clo <= 8)
                {
                   
                    if((row ==1 && clo ==1) ||(row == 1 && clo % 2 == 1))
                    {
                        message = message + "(" + columnInString[clo-1] + row + ":dark)" ;
                    }else if(row%2 == 1 && clo%2 == 1)
                    {
                        message = message + "(" + columnInString[clo-1] + row + ":dark)" ;
                    }
                    else if(row%2 ==0 && clo%2==0)
                    {
                        message = message + "(" + columnInString[clo - 1] + row + ":dark)";
                    }
                    else
                    {
                        message = message + "(" + columnInString[clo - 1] + row + ":light)" ;
                    }
                    message = message + ",";
                    clo++;
                }

                row++;
            }
            message = message.TrimEnd(message[message.Length - 1]);
            return message;
        }

    }
}
    

