using System.Collections;

namespace AdventOfCode2022.Day1;

public class Solution
{
    private string [] LoadElvesData ()
    {
        return File.ReadAllLines ("Data/Day1/input");
    }

    private int [] SumUpElvesCalories (string [] data)
    {
        IEnumerable<string> cleanedUpValues = data.Select (x => x.Trim ());
        List <int> result = new List <int> ();
        int accumulator = 0;

        foreach (string value in cleanedUpValues)
        {
            if (string.IsNullOrEmpty (value) == true)
            {
                result.Add (accumulator);
                accumulator = 0;
                continue;
            }

            accumulator += int.Parse (value);
        }

        return result.ToArray ();
    }

    private IEnumerable <int> SortedDescendent (int [] data)
    {
        return data.OrderByDescending (x => x);
    }
    
    public void FirstPart ()
    {
        string[] data = this.LoadElvesData ();
        int [] caloriesSum = SumUpElvesCalories (data);

        Console.WriteLine (SortedDescendent (caloriesSum).First ());
    }

    public void SecondPart ()
    {
        string[] data = this.LoadElvesData ();
        int [] caloriesSum = SumUpElvesCalories (data);

        Console.WriteLine (SortedDescendent (caloriesSum).Take (3).Sum());
    }
}