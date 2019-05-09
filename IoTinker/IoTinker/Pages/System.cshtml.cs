using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Device.Gpio;
using IoTinker.Core;
using System.Diagnostics;

namespace IoTinker.Pages
{
    [Authorize]
    public class SystemModel : PageModel
    {
        private const int pin = 17;

        public void OnGet()
        {
        }

        public void OnPostToggle()
        {
            try
            {
                PinState state = Core.System.ReadState(pin);
                state.StateOn = !state.StateOn;
                string x = Core.System.Toggle(state);
                Trace.TraceInformation(x);
                //GpioController controller = new GpioController();
                //if (!controller.IsPinOpen(pin))
                //{
                //    controller.OpenPin(pin, PinMode.Input);
                //}

                //var mode = controller.GetPinMode(pin);
                //if (!PinMode.Input.Equals(mode)) controller.SetPinMode(pin, PinMode.Input);
                //var x = controller.Read(pin);
                //mode = controller.GetPinMode(pin);
                //if (!PinMode.Output.Equals(mode)) controller.SetPinMode(pin, PinMode.Output);
                //controller.Write(pin, PinValue.High.Equals(x) ? PinValue.Low : PinValue.High);

            }
            catch (Exception ex)
            {
                //TODO: log Error
                return;
            }
        }
    }
}