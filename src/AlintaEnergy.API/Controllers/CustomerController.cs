using AlintaEnergy.Application.Services;
using AlintaEnergy.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlintaEnergy.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ApiController
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IAppService _appService;

        public CustomerController(ILogger<CustomerController> logger, IAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            var vm = _appService.GetCustomers();
            return Response(vm);
        }

        [HttpGet("{id}")]
        public ActionResult GetCustomerById(int id)
        {
            var vm = _appService.GetCustomerById(id);
            if (vm == null)
            {
                return ResponseNotFound();
            }
            return Response(vm);
        }

        [HttpGet]
        public ActionResult GetCustomersSearch(string search)
        {
            var vm = _appService.GetCustomersSearch(search);
            return Response(vm);
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody] CustomerVM value)
        {
            _appService.AddCustomer(value);

            return Response("", value);
        }

        [HttpPut]
        public ActionResult UpdateCustomer([FromBody] CustomerVM value)
        {
            _appService.UpdateCustomer(value);

            return Response();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _appService.DeleteCustomer(id);

            return Response();
        }
    }
}
