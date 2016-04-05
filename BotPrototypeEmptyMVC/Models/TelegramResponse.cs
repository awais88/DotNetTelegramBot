namespace BotPrototypeEmptyMVC.Models
{
    public class TelegramResponse
    {
        public int Id { get; set; }
        public string JsonData { get; set; }
    }

    public class TelegramAwaitable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AwaitableTag { get; set; }
        public bool Awaiting { get; set; }
    }
}