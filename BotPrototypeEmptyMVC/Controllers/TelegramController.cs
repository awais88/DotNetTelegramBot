using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using BotPrototypeEmptyMVC.Models;
using System.Linq;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Configuration;

namespace BotPrototypeEmptyMVC.Controllers
{
    public class TelegramController : Controller
    {
        private BotPrototypeEmptyMVCContext db = new BotPrototypeEmptyMVCContext();
        protected string telegramSecretUrl = WebConfigurationManager.AppSettings["TelegramSecretUrl"];

        // Telegram webhook method
        [HttpPost]
        public async new Task<ActionResult> TellMeTelegram()
        {
            Stream req = Request.InputStream;
            req.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            // JSON to C# Ojbect
            TelegramWebhookUpdate result = new JavaScriptSerializer().Deserialize<TelegramWebhookUpdate>(json);

            // Save chat logs into database
            TelegramResponse response = new TelegramResponse();
            response.JsonData = "Text Message: " + result.message.text + " | JSON Response: " + json;
            db.Responses.Add(response);
            db.SaveChanges();

            // Check awaitable messages
            var awaitable = db.Awaitable.Where(i => i.UserId == result.message.from.id && i.Awaiting == true).FirstOrDefault();
            if (awaitable != null)
            {
                await ProcessAwaitableMessage(awaitable, result);
                return null;
            }

            // Process initial messages
            await ProcessInitialMessage(result);

            return null;
        }

        // Process awaitable message from user
        public async Task ProcessAwaitableMessage(TelegramAwaitable awaitable, TelegramWebhookUpdate result)
        {
            // Reply on awaitable
            SendMessageObject sendMessage = new SendMessageObject();
            sendMessage.chat_id = result.message.chat.id.ToString();
            sendMessage.text = "Reply from ProcessAwaitableMessage method, need to implement this method.";

            await SendTextMessage(sendMessage);

            // TODO: Implement logics under /event call





            // Update awaitable message in database
            UpdateAwaitableMessage(result);
        }

        // Process initial message from user
        public async Task ProcessInitialMessage(TelegramWebhookUpdate result)
        {
            if (result.message.text == "/event")
            {
                SendMessageObject sendMessage = new SendMessageObject();
                sendMessage.chat_id = result.message.chat.id.ToString();
                sendMessage.text = "Welcome " + result.message.chat.first_name + " on .NET BOT self help service. Please send your location to know more about events.";

                // Insert awaitable in database
                InsertAwaitableMessage(result);

                await SendTextMessage(sendMessage);
            }
            else if (result.message.text == "/hello")
            {
                SendMessageObject sendMessage = new SendMessageObject();
                sendMessage.chat_id = result.message.chat.id.ToString();
                sendMessage.text = "Hi " + result.message.chat.first_name + ", I'm a .NET BOT. Just send me /help to begin.";

                await SendTextMessage(sendMessage);
            }
            else if (result.message.text == "/help")
            {
                SendMessageObject sendMessage = new SendMessageObject();
                sendMessage.chat_id = result.message.chat.id.ToString();
                sendMessage.text = "Nice to meet you " + result.message.chat.first_name + ", i can help you to find events around you. Just send me /event to begin.";

                await SendTextMessage(sendMessage);
            }
            else
            {
                SendMessageObject sendMessage = new SendMessageObject();
                sendMessage.chat_id = result.message.chat.id.ToString();
                sendMessage.text = ":( I don't get this. Send /help to begin.";

                await SendTextMessage(sendMessage);
            }
        }

        // Insert awaitable message in database
        public void InsertAwaitableMessage(TelegramWebhookUpdate result)
        {
            TelegramAwaitable awaitable = new TelegramAwaitable();
            awaitable.UserId = result.message.from.id;
            awaitable.AwaitableTag = "event";
            awaitable.Awaiting = true;
            db.Awaitable.Add(awaitable);
            db.SaveChanges();
        }

        // Update awaitable message in database
        public void UpdateAwaitableMessage(TelegramWebhookUpdate result)
        {
            TelegramAwaitable awaitable = new TelegramAwaitable();
            awaitable = db.Awaitable.Where(i => i.UserId == result.message.from.id && i.Awaiting == true).FirstOrDefault();
            awaitable.Awaiting = false;
            db.SaveChanges();
        }

        // NOTE: This is one time use method which tells Telegram to use below address to send response on any update
        public async Task<ActionResult> SetWebhook()
        {
            // Target URI (https required on target)
            string url = telegramSecretUrl + "setWebhook?url=" + WebConfigurationManager.AppSettings["WebhookTargetUrl"];
            string result = string.Empty;

            // HttpClient
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                // Read the string
                result = await content.ReadAsStringAsync();
            }

            return Content(result);
        }

        // Send text message to telegram user
        public async Task<ActionResult> SendTextMessage(SendMessageObject message)
        {
            // Target URI
            string url = telegramSecretUrl + "sendMessage?chat_id=" + message.chat_id + "&text=" + message.text;
            string result = string.Empty;

            // HttpClient
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                // Read the string
                result = await content.ReadAsStringAsync();
            }

            return Content(result);
        }


        /// <summary>
        /// Some optional methods below which will help you to debug
        /// </summary>

        // Telegram message logs: in case you would like to see what's going on
        [HttpGet]
        public ActionResult WebhookResponse()
        {
            return View(db.Responses.ToList().OrderByDescending(i => i.Id));
        }

        // Telegram BOT details: in case you would like to know about live telegram
        public async Task<ActionResult> GetMe()
        {
            // Target URI
            string url = telegramSecretUrl + "getMe";
            string result = string.Empty;

            // HttpClient
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                // Read the string
                result = await content.ReadAsStringAsync();
            }

            return Content(result);
        }

        // Telegram service home page
        public ActionResult Index()
        {
            return View();
        }
    }
}
