using System.Net.Quic;
using System.Security.Principal;

string? FirstPlayerName;
string? SecondPlayerName;
int FirstPlayerPoints = 0;
int SecondPlayerPoints = 0;
int minNumber;
int maxNumber;
int RoundNumber;

Console.WriteLine("First Player, write your name:");
FirstPlayerName = Console.ReadLine() ?? string.Empty;
Console.WriteLine("Second Player, write your name:");
SecondPlayerName = Console.ReadLine() ?? string.Empty;

Console.WriteLine("How many rounds do you want to play?");
int.TryParse(Console.ReadLine(), out int maxRounds);

Console.WriteLine("Specify minimal number:");
bool minParsingResult = int.TryParse(Console.ReadLine(), out minNumber);
if(!minParsingResult)
{
	minNumber = 1;
}

Console.WriteLine("Specify max number:");
bool maxParsingResult = int.TryParse(Console.ReadLine(), out maxNumber);
if(!maxParsingResult)
{
	maxNumber = 100;
}

for (RoundNumber = 1; RoundNumber <= maxRounds; RoundNumber++)
{
	int FirstPlayerNumber = 0;
	int SecondPlayerNumber = 0;
	
	//Pierwsza połowa rundy
	SecondPlayerNumber = GetPlayerNumber(SecondPlayerNumber, SecondPlayerName);
	FirstPlayerNumber = GetPlayerNumber(FirstPlayerNumber, FirstPlayerName);
	FirstPlayerPoints = CountPoints(FirstPlayerNumber, SecondPlayerNumber, FirstPlayerPoints, FirstPlayerName);

	//Druga połowa rundy
	FirstPlayerNumber = GetPlayerNumber(FirstPlayerNumber, FirstPlayerName);
	SecondPlayerNumber = GetPlayerNumber(SecondPlayerNumber, SecondPlayerName);
	SecondPlayerPoints = CountPoints(FirstPlayerNumber, SecondPlayerNumber, SecondPlayerPoints, SecondPlayerName);

	Console.WriteLine($"--Round {RoundNumber} Results: {FirstPlayerName}: {FirstPlayerPoints} --- {SecondPlayerName}: {SecondPlayerPoints}");
}

if(FirstPlayerPoints>SecondPlayerPoints)
{
	Console.WriteLine($"{FirstPlayerName} WINS!!! Points: {FirstPlayerName}: {FirstPlayerPoints} --- {SecondPlayerName}: {SecondPlayerPoints}");
}
else if(SecondPlayerPoints>FirstPlayerPoints)
{
	Console.WriteLine($"{SecondPlayerName} WINS!!! Points: {FirstPlayerName}: {FirstPlayerPoints} --- {SecondPlayerName}: {SecondPlayerPoints}");
}
else if(FirstPlayerPoints == SecondPlayerPoints)
{
	Console.WriteLine($"It's a TIE!!! Points: {FirstPlayerName}: {FirstPlayerPoints} --- {SecondPlayerName}: {SecondPlayerPoints}");
}

Console.WriteLine("Press any key to close...");
Console.ReadKey();

int CountPoints(int FirstNumber, int SecondNumber, int Points, string PlayerName)
{
	int RoundPoints = maxNumber - Math.Abs(FirstNumber - SecondNumber);
	Points = Points + RoundPoints;
	Console.WriteLine($"The numbers written were P1: {FirstNumber} --- P2: {SecondNumber}");
	Console.WriteLine($"{PlayerName} got {RoundPoints} points");
	return Points;
}

int GetPlayerNumber(int PlayerNumber, string PlayerName)
{
	Console.WriteLine($"{PlayerName}, pick a number from {minNumber} to {maxNumber}");
	int.TryParse(Console.ReadLine(), out PlayerNumber);
	while (minNumber>PlayerNumber || maxNumber<PlayerNumber)
	{
		Console.WriteLine($"Wrong number, pick a number from {minNumber} to {maxNumber}");
		int.TryParse(Console.ReadLine(), out PlayerNumber);
	}
	return PlayerNumber;
}