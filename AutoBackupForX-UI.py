# Install python-telegram-bot package from pip
import os
import time
import telegram
import asyncio

# Replace with your bot token and channel name
bot_token = "your bot token here"
channel = "@your channel name here or id"

# Create a bot instance
bot = telegram.Bot(token=bot_token)

# Get the file name and path
file_name = "x-ui.db"
file_path = os.path.join(os.getcwd(), file_name)

# Define an async function
async def send_file():
    # Create a loop to send the file every hour
    while True:
        print(f"Sending {file_path} to {channel}...")

        # Open the file as a binary stream
        with open(file_path, "rb") as file:
            # Send the file as a document
            await bot.send_document(
                chat_id=channel,
                document=file,
                filename=file_name
            )

        print("File sent successfully.")

        # Wait for an hour (3600 seconds)
        await time.sleep(3600)

if name == 'main': 
    loop = asyncio.new_event_loop() 
    asyncio.set_event_loop(loop) 
    loop.run_until_complete(send_file())
