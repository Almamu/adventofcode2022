namespace AdventOfCode2022.Day3;

public class Solution
{
    class Rucksacks
    {
        public string Compartment1 { get; init; }
        public string Compartment2 { get; init; }
        public string Contents => this.Compartment1 + this.Compartment2;

        public char Compare (Rucksacks first, Rucksacks second)
        {
            string firstContents = first.Contents;
            string secondContents = second.Contents;

            return this.Contents.First (x => firstContents.Contains (x) && secondContents.Contains (x));
        }
        
        public static explicit operator Rucksacks(string value)
        {
            return new Rucksacks ()
            {
                Compartment1 = value.Substring (0, value.Length / 2),
                Compartment2 = value.Substring (value.Length / 2)
            };
        }

        public char [] RepeatedElements => this.Compartment1.Where (x => this.Compartment2.Contains (x)).Distinct().ToArray ();
    }
    
    private string [] ReadInputFile ()
    {
        return File.ReadAllLines ("Data/Day3/input");
    }

    private IEnumerable <Rucksacks> ReadRucksacks (string[] lines)
    {
        return lines.Select (x => (Rucksacks) x);
    }

    public void FirstPart ()
    {
        int value = ReadRucksacks (ReadInputFile ()).Sum (x => x.RepeatedElements.CalculatePoints ());

        Console.WriteLine (value);
    }

    public void SecondPart ()
    {
        int value = ReadRucksacks (ReadInputFile ())
            .Select ((x, index) => new {x, index})
            .GroupBy (x => x.index / 3)
            .Select (x =>
            {
                Rucksacks [] elements = x.Take (3).Select (x => x.x).ToArray ();

                return elements [0].Compare (elements [1], elements [2]);
            })
            .CalculatePoints ();

        Console.WriteLine (value);
    }
}