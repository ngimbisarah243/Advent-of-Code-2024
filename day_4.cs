using System;
using System.Text.RegularExpressions;

var input = File.ReadAllLines("C:\\ProgrammingStuff\\AOC_2024\\day_4\\input.txt");

var original = "XMAS";
var reverse = "SAMX";
int count = 0;
int count2 = 0;

foreach (var row in input)
{
	count += CountMatch(row);

}

var arrVertical = "";
int columns = input.Length;

for (int i = 0; i < columns; i++)
{
	arrVertical = "";
	for (int j = 0; j < input.Length; j++)
	{
		arrVertical += input[j][i];
	}
	count += CountMatch(arrVertical);
}

int rows = input.Length;
int cols = input[0].Length;


//  links oben nach rechts unten .........(↘)
for (int startCol = 0; startCol < cols; startCol++) //  starten in der Oberen Reihe
{
	string diagonal = "";
	for (int row = 0, col = startCol; row < rows && col < cols; row++, col++)
	{
		diagonal += input[row][col];
	}
	count += CountMatch(diagonal);

}
for (int startRow = 1; startRow < rows; startRow++) // starte in  der linken Spalte
{
	string diagonal = "";
	for (int row = startRow, col = 0; row < rows && col < cols; row++, col++)
	{
		diagonal += input[row][col];
	}
	
	count += CountMatch(diagonal);
}

//  rechts oben nach links unten......... (↙)
for (int startCol = cols - 1; startCol >= 0; startCol--) // starte oberen 
{
	string diagonal = "";
	for (int row = 0, col = startCol; row < rows && col >= 0; row++, col--)
	{
		diagonal += input[row][col];
	}
	
	count += CountMatch(diagonal);

}
for (int startRow = 1; startRow < rows; startRow++) // starte in  der rechten Spalte
{
	string diagonal = "";
	for (int row = startRow, col = cols - 1; row < rows && col >= 0; row++, col--)
	{
		diagonal += input[row][col];
	}

	count += CountMatch(diagonal);
}




for (int i = 1; i < rows - 1; i++)
{
	for (int j = 1; j < cols - 1; j++)
	{
		if (input[i][j] == 'A')
		{
		
			bool topLeftBottomRight = input[i - 1][j - 1] == 'M' && input[i + 1][j + 1] == 'S';   // ↘
			bool topRightBottomLeft = input[i - 1][j + 1] == 'M' && input[i + 1][j - 1] == 'S'; // ↙
			bool bottomLeftTopRight = input[i + 1][j - 1] == 'M' && input[i - 1][j + 1] == 'S'; // ↗
			bool bottomRightTopLeft = input[i + 1][j + 1] == 'M' && input[i - 1][j - 1] == 'S';  // ↖

			if (topLeftBottomRight && topRightBottomLeft || topLeftBottomRight && bottomLeftTopRight || topRightBottomLeft && bottomRightTopLeft || bottomLeftTopRight && bottomRightTopLeft)
			{
				count2++;
			}
		
		}
	}
}

int CountMatch(string row)
{
	string patternXMAS = @"(?=XMAS)";
	string patternSAMX = @"(?=SAMX)";

	Regex regexXMAS = new Regex(patternXMAS);
	Regex regexSAMX = new Regex(patternSAMX);

	int matchCount = 0;
	matchCount += regexXMAS.Matches(row).Count;
	matchCount += regexSAMX.Matches(row).Count;

	return matchCount;

}


Console.WriteLine(count);
Console.WriteLine(count2);



