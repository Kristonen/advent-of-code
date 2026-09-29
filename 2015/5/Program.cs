using System.Reflection.Metadata.Ecma335;
using System.Text;

char[] vowels = ['a', 'e', 'i', 'o', 'u'];
string[] forbidden = ["ab", "cd", "pq", "xy"];
string txt = File.ReadAllText("puzzle.txt");
string[] letters = txt.Split('\n');
// PartOne(letters);
//PartTwo(letters);


void PartOne(string[] letters)
{
    Console.WriteLine("-------------------PART ONE-------------------");
    int nice_letters = 0;
    foreach(string letter in letters)
    {
        if(!CheckForVowels(letter)) continue;
        if(!CheckForDoubles(letter)) continue;
        if(!CheckIfForbidden(letter)) continue;
        nice_letters++;
    }
    Console.WriteLine($"THere are {nice_letters} nice letters!");
}

void PartTwo(string[] letters)
{
    Console.WriteLine("-------------------PART TWO-------------------");
    int nice_letters = 0;
    foreach(string letter in letters)
    {
        if(!CheckForDoubleCombos(letter)) continue;
        if(!CheckRepeatWithOneOtherLetterBetween(letter)) continue;
        nice_letters++;
    }
    Console.WriteLine($"There are {nice_letters} nice letters!");
}

bool CheckForVowels(string letter, int needed_count = 3)
{
    int count = 0;
    for (int i = 0; i < letter.Length; i++)
    {
        char c = letter[i];
        if(vowels.Contains(c)) count++;

        if(count == needed_count) return true;
    }

    return false;
}

bool CheckForDoubles(string letter)
{
    char c = 'a';
    while(c != 'z' + 1)
    {
        string doubleLetter = $"{c}{c}";
        c++;
        if(letter.Contains(doubleLetter)) return true;
    }
    return false;
}

bool CheckIfForbidden(string letter)
{
    foreach(string forbiddenString in forbidden)
    {
        if(letter.Contains(forbiddenString)) return false;
    }
    return true;
}

bool CheckForDoubleCombos(string letter)
{
    for (int i = 0; i < letter.Length - 1; i++)
    {
        string combo = $"{letter[i]}{letter[i + 1]}";
        StringBuilder builder = new(letter);
        builder[i] = '?';
        builder[i + 1] = '!';
        string tmp = builder.ToString();
        if(tmp.Contains(combo)) return true;
    }
    return false;
}

bool CheckRepeatWithOneOtherLetterBetween(string letter)
{
    for (int i = 0; i < letter.Length - 2; i++)
    {
        char c = letter[i];
        if(c == letter[i + 2]) return true;
    }
    return false;
}