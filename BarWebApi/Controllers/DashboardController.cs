using System.Collections.Generic;
using BarWebApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace BarWebApi.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController
    {
        // GET api/values
        [HttpGet]
        public BarcodeUtils.BarcodeModel Get()
        {
            BarcodeUtils.BarcodeModel bmModel = BarcodeUtils.BarcodeCustomReader();  
            return bmModel;
        }
        
    }
}