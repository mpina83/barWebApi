using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BarWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        // GET api/values
        [HttpGet]
        public ClientResults Get()
        {
            ClientResults clResult  = new ClientResults()
            {
                results = new string[] {"Joao", "Filipe","José"}
            };
            return clResult;
        }
    }
    
    public class ClientResults
    {
        public string[] results { get; set; }
    }
}

