# Azure Text-to-Speech Demo

This project is a simple web application that demonstrates the usage of Azure's Text-to-Speech service. It allows users to input text and convert it to speech using Microsoft's Azure Cognitive Services.

## Features

- Convert text to speech using Azure's Text-to-Speech API
- Simple and intuitive user interface
- Real-time audio playback in the browser
- Visual indicator when audio is playing

## Technologies Used

- ASP.NET Core MVC
- C#
- JavaScript/jQuery
- Azure Cognitive Services (Speech Service)

## Prerequisites

Before you begin, ensure you have the following:

- .NET 6.0 SDK or later
- An Azure account with an active subscription
- Azure Speech Service resource

## Setup

1. Clone the repository:
   ```
   git clone https://github.com/thegreatgabuza/text-to-speech-demo-dut.git
   ```

2. Navigate to the project directory:
   ```
   cd text-to-speech-demo-dut
   ```

3. Update the `appsettings.json` file with your Azure Speech Service credentials:
   ```json
   {
     "AzureSpeech": {
       "SubscriptionKey": "your-subscription-key",
       "Region": "your-region"
     }
   }
   ```

4. Restore the required packages:
   ```
   dotnet restore
   ```

5. Build and run the application:
   ```
   dotnet run
   ```

6. Open a web browser and navigate to `https://localhost:5001` (or the port specified in the console output).

## Usage

1. Enter the text you want to convert to speech in the provided text area.
2. Click the "Convert to Speech" button.
3. Allow the browser to use audio if prompted.
4. The converted speech will play automatically through your device's speakers.



## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgments

- Microsoft Azure for providing the Text-to-Speech service
- The ASP.NET Core team for the excellent web framework
