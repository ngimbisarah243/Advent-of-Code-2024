var input = File.ReadAllLines("C:\\ProgrammingStuff\\AOC_2024\\day_2\\input.txt");
int count = 0;


foreach (var line in input)
{
	var arrNum = line.Split(' ').Select(int.Parse).ToList();
	if (IsASafeLine(arrNum))
	{
		count++;
		continue;
	}

	bool maybe = false;

	for (int i = 0; i < arrNum.Count; i++)
	{
		var reducedLevels = arrNum.Where((_, index) => index != i).ToList();

		if (IsASafeLine(reducedLevels))
		{
			maybe = true;
			break;
		}
	}

	if (maybe)
		count++;


}

Console.WriteLine(count);


bool IsASafeLine(List<int> input)
{
	bool isIncreasing = false;
	bool isDecreasing = false;
	bool isValid = true;
	var old = 0;

	for (int i = 0; i < input.Count; i++)
	{
		int num = 0;

		if (i == 0) { old = input[i]; continue; }
		else { num = input[i]; }
		if (num < old)
		{
			isDecreasing = true;
		}
		if (num > old)
		{
			isIncreasing = true;
		}
		if (Math.Abs(num - old) > 3 || Math.Abs(num - old) < 1) { isValid = false; break; }
		if (isDecreasing && isIncreasing) { isValid = false; break; }
		old = num;

	}
	return isValid;
}

