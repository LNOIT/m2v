Move to Voice - Play Chess with a Voice Interface

Move to Voice is a chess client designed for playing chess online through a server. Its main purpose is to create a program with an interface tailored for visually impaired players. However, one could also humorously add that since the entire humanity is blind, it should naturally provide a good user experience for sighted players as well.

The program provides feedback to users through a spoken voice or text boxes that users can navigate to (in case the text-to-speech feature is provided by an external program).

It is also designed to accommodate players with visual impairments, allowing customization of text size and the overall layout of the program.

The program aims to be user-configurable, allowing users to enable or disable the speech synthesis feature and create shortcuts and buttons for server commands.

The program is developed for Windows and will utilize the Windows Registry to store configuration data.


Please note that the program currently only uses the included Stockfish engine, which needs to be in the same folder as the program.

The program is written in C# and utilizes the Chess.net library [<HintPath>..\packages\ChessDotNet.0.12.3\lib\netstandard1.3\ChessDotNet.dll</HintPath>] (although it may not be immediately used in the project, it is likely to be useful in the future).

The Telnet class is the only class, apart from Chess.net, created outside of this project. It is a free class found online, but unfortunately, I couldn't find information about the programmer.

The project mainly consists of the following classes and other files:

Directory of d:\code\4
2023-05-29 20:47 <DIR> .
2023-05-29 20:47 <DIR> ..
2023-05-30 23:03 <DIR> bin
2023-05-30 23:03 <DIR> obj
2023-05-30 23:03 <DIR> Properties
2023-05-30 17:47 Form1.Designer.cs
2023-05-30 17:47 Form1.cs
2023-05-30 17:47 Form1.resx
2023-05-30 13:33 Speech.cs
2023-05-28 17:01 Engine.cs
2023-05-28 14:26 ChessInterface.cs
2023-05-27 12:14 TelnetConnection.cs
2023-05-22 16:32 Move2VoiceBeta.csproj
2023-05-20 14:26 Form11.cs
2023-05-20 08:55 packages.config
2023-05-20 08:46 Program.cs
2023-05-19 22:31 App.config


