using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_week5.Controllers
{
    public class LoopsWeek5Controller : ApiController
    {

        //challenge 1
        //print 1 to 25 counting by 1s
        //GET /api/LoopsWeek5/C1While
        [HttpGet]
        
        public string C1While()
        {
            string message = "";
            int i = 1;
            while (i <= 25)
            {
                //adding i to the mesage
                message = message + i.ToString() + ",";
                //incrementing our iterating variable
                i++;
            }
            return message;
        }

        //GET /api/LoopsWeek5/C1For
        //print 1 to 25 counting by 1s
        [HttpGet]
        public string C1For()
        {
            string message = "";
            int i;
            for(i = 1; i <=25; i++)
            {
                message = message + i.ToString() + ",";
            }

            return message;
        }


        //challenge 2
        //pring -10 to 10 counting by 1s
        //GET /api/LoopsWeek5/C2While
        [HttpGet]
        public string C2While()
        {
            string message = "";
            int i = -10;
            while(i <= 10)
            {
                message = message + i.ToString() + ",";
                i++;
            }
            return message;
        }

        //pring -10 to 10 counting by 1s
        //GET /api/LoopsWeek5/C2For
        [HttpGet]
        public string C2For()
        {
            string message = "";
            for(int i = -10; i <= 10; i++)
            {
                message = message + i.ToString() + ",";
            }
            return message;
        }


        //challenge 3
        //pring -20 to -10 counting by 2s
        //GET /api/LoopsWeek5/C3While
        [HttpGet]
        public string C3While()
        {
            string message = "";
            int i = -20;
            while (i<-9)
            {
                message = message + i.ToString() + ",";
                i = i + 2;
            }
            return message;
        }

        //pring -20 to -10 counting by 2s
        //GET /api/LoopsWeek5/C3For
        [HttpGet]
        public string C3For()
        {
            string message = "";
            for(int i = -20; i < -9; i += 2)
            {
                message = message + i.ToString() + ",";
            }
            return message;
        }


        //challenge 4
        //print -30 to 30 counting by 4s
        //GET /api/LoopsWeek5/C4While
        [HttpGet]
        public string C4While()
        {
            string message = "";
            int i = -30;
            while (i<=30)
            {
                message = message + i.ToString() + ",";
                i = i + 4;
            }
            return message;
        }
        //print -30 to 30 counting by 4s
        //GET /api/LoopsWeek5/C4For
        [HttpGet]
        public string C4For()
        {
            string message = "";
            for(int i =-30; i <= 30; i += 4)
            {
                message = message + i.ToString() + ",";
            }
            return message;
        }



        //challenge 5
        //create an array of favorite movies, pring each one
        //GET /api/LoopsWeek5/C5While
        [HttpGet]
        public string C5While()
        {
            //array of strings (using {})
            string[] movies = { "Harry Potter", "Spider Man", "Avatar" };
            string message = "";
            int i = 0;
            while (i < movies.Length)
            {
                string delimeter = ",";
                if (i == (movies.Length - 1))
                {
                    delimeter = ".";
                }
                message = message + movies[i] + delimeter;
                i = i + 1;
            }
            return message;
        }

        //create an array of favorite movies, pring each one
        //IEnumerable<string> movies
        [HttpGet]
        public string C5WhileIEnumer()
        {
            IEnumerable<string> movies = new string[] { "Harry Potter", "Spider Man", "Avatar" };
            string message = "";
            int i = 0;
            foreach(string movie in movies)
            {
                string delimeter = ",";
                if (i == (movies.Count() - 1))
                {
                    delimeter = ".";
                }
                message = message + movie + delimeter;
                i = i + 1;
            }
            return message;
        }



        //create an array of favorite movies, pring each one
        //GET /api/LoopsWeek5/C5For
        [HttpGet]
        public string C5For()
        {
            string[] movies = { "Harry Potter", "Spider Man", "Avatar" };
            string message = "";
            for(int i = 0; i < movies.Length; i++)
            {
                string delimeter = ",";
                if (i == movies.Length - 1)
                {
                    delimeter = ".";
                }
                message = message + movies[i]+delimeter;
            }
            return message;
        }
    }
}
