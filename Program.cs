using Telegram.Bot;

string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine(currentDirectory);

//Replace with your bot token and channel name
string botToken = "your bot token here";
string channelName = "@your channel name here";


// Create a bot instance
var bot = new TelegramBotClient(botToken);

// Get the chat id of the channel
var chat = await bot.GetChatAsync(channelName);
var chatId = chat.Id;

// Get the file name and path
var fileName = "x-ui.db";
var filePath = Path.Combine(Environment.CurrentDirectory, fileName);

// Create a timer to send the file every hour
var timer = new System.Timers.Timer(3600000); // 3600000 milliseconds = 1 hour
timer.Elapsed += async (sender, e) => await SendFileAsync(bot, chatId, filePath);
timer.Start();

Console.WriteLine("Press any key to stop the bot...");
Console.ReadKey();

timer.Stop();

// A method to send the file to the channel
static async Task SendFileAsync(TelegramBotClient bot, long chatId, string filePath)
{
    Console.WriteLine($"Sending {filePath} to {chatId}...");

    // Create a stream to read the file
    using (var stream = File.OpenRead(filePath))
    {
        // Send the file as a document with a caption
        await bot.SendDocumentAsync(
            chatId: chatId,
            document: stream,
            caption: Path.GetFileName(filePath)
        );
    }

    Console.WriteLine("File sent successfully.");
}
