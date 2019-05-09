using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Text;
using System.Threading.Tasks;

namespace IoTinker.Core
{
    public static class System
    {
        public static string Toggle(PinState state)
        {
            try
            {
                GpioController controller = new GpioController();
                if (!controller.IsPinOpen(state.Pin))
                {
                    controller.OpenPin(state.Pin, PinMode.Output);
                }

                if (state.StateOn)
                {
                    controller.Write(state.Pin, PinValue.High);
                    return $"Toggled pin {state.Pin} on";
                }
                else
                {
                    controller.Write(state.Pin, PinValue.Low);
                    return $"Toggled pin {state.Pin} off";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static PinState ReadState(int pin)
        {
            PinState state = new PinState
            {
                Pin = pin,
                StateOn = false
            };
            try
            {
                GpioController controller = new GpioController();
                if (!controller.IsPinOpen(pin))
                {
                    controller.OpenPin(pin, PinMode.Input);
                }

                var mode = controller.GetPinMode(pin);
                if (!PinMode.Input.Equals(mode)) controller.SetPinMode(pin, PinMode.Input);
                var x = controller.Read(pin);
                if(x.Equals(PinValue.High)) state.StateOn = true;
            }
            catch (Exception ex)
            {
                //TODO: log Error
                
            }
            return state;
        }
    }
}
