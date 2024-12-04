using System.Text.RegularExpressions;

var input = File.ReadAllText("C:\\ProgrammingStuff\\AOC_2024\\day_3\\input.txt");

bool isActive = true;
var @do = new Regex(@"do\(\)");
var dont = new Regex(@"don't\(\)");
var mulRegex = new Regex(@"mul\((\d+),(\d+)\)");


int sum = 0;

foreach (Match match in Regex.Matches(input, @"mul\(\d+,\d+\)|do\(\)|don't\(\)"))
{

	if (@do.IsMatch(match.Value))
	{
		isActive = true;
	}
	else if (dont.IsMatch(match.Value))
	{
		isActive = false;
	}
	else if (isActive && mulRegex.IsMatch(match.Value))
	{

		var mulMatch = mulRegex.Match(match.Value);
		int x = int.Parse(mulMatch.Groups[1].Value);
		int y = int.Parse(mulMatch.Groups[2].Value);


		sum += x * y;
	}
}

Console.WriteLine(sum);