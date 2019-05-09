using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;
using Microsoft.AspNetCore.Authorization;
using IoTinker.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using IoTinker.Core;

namespace IoTinker.API
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get(string input)
        {
            return Ok(input?.ToUpper());
        }
        [HttpPost]
        public ActionResult<string> Post([FromBody] PinState state)
        {
            try
            {
                return Ok(Core.System.Toggle(state));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}