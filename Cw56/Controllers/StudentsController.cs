using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cw5.Exceptions;
using Cw5.Models;
using Cw5.Services;

namespace Cw5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {


        private const string ConString = "Data Source=db-mssql;Initial Catalog=s16703;Integrated Security=True";
       
        private readonly IDbService _dbStudentService;

        public StudentsController(IDbService dbService)
        {
            _dbStudentService = dbService;
        }
    }
}
