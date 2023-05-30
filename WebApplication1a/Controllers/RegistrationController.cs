using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication1a.Models;

namespace WebApplication1a.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Registration")]

        public Response Registration(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection=new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());


            return response;



        }
    }
}
