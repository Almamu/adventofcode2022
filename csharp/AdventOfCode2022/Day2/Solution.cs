namespace AdventOfCode2022.Day2;

public class Solution
{
    struct MovementInfo
    {
        public Move Opponent;
        public Move Ours;
        
        public int Part1Points => Opponent.ToMatchPoints (Ours);
        public int Part2Points => Opponent.ToMatchPoints (Opponent.ToMovement (Ours));
    }

    private string [] ReadInputFile ()
    {
        return File.ReadAllLines ("Data/Day2/input");
    }

    private MovementInfo Convert (string line)
    {
        string [] options = line.Split (' ');

        Move.TryParse (options [0], out Move opponent);
        Move.TryParse (options [1], out Move ours);

        return new MovementInfo
        {
            Opponent = opponent,
            Ours = ours
        };
    }

    private IEnumerable <MovementInfo> Parse (string[] data)
    {
        return data.Select (x => Convert (x));
    }
    
    public void FirstPart ()
    {
        string [] lines = this.ReadInputFile ();
        IEnumerable <MovementInfo> movements = Parse (lines);

        Console.WriteLine (movements.Sum (x => x.Part1Points));
    }

    public void SecondPart ()
    {
        string [] lines = this.ReadInputFile ();
        IEnumerable <MovementInfo> movements = Parse (lines);

        Console.WriteLine (movements.Sum (x => x.Part2Points));
    }
}