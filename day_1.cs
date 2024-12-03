using System.Collections.Generic;

var input = File.ReadAllLines("C:\\ProgrammingStuff\\AOC_2024\\day_1\\input.txt");

var left = new List<int>();
var right = new List<int>();

#region Part 1

foreach (var line in input)
{

	var leftPart = int.Parse(line.Split("  ")[0].Trim());
	var rightPart = int.Parse(line.Split("  ")[1].Trim());

	left.Add(leftPart);
	right.Add(rightPart);
}

left.Sort();
right.Sort();

Console.WriteLine(left.Zip(right, (a, b) => Math.Abs(a - b)).Sum());

#endregion

#region Part 2

var occurences = new List<int>();

foreach (var leftElement in left)
{
	int count = 0;
	foreach (var rightElement in right)
	{
		count += leftElement == rightElement ? 1 : 0;
	}
	occurences.Add(count);

}

Console.WriteLine(left.Zip(occurences, (a, b) => a * b).Sum());

#endregion