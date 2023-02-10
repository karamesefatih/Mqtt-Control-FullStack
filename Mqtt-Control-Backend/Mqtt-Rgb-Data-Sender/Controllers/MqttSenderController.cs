using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Mqtt_Rgb_Data_Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MqttSenderController : ControllerBase
    {
        private MqttClient mqttclient;

        [HttpPost]
        public IActionResult SendToMqtt(mqttDto dto)
        {

            mqttclient = new MqttClient("your mqtt client");
            //Connecting to mqtt client here
            mqttclient.Connect("your mqtt client");
            //Publishing the message that response from frontend here
            mqttclient.Publish("/"+dto.mac_address, Encoding.UTF8.GetBytes(dto.message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            //Response here
            return Ok("Message Successed");
        }
    }
}
