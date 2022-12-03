namespace AdventOfCode2022.Day2;

public static class Extensions
{
    public static bool IsDraw (this Move move, Move other)
    {
        return move == other;
    }

    public static bool IsWon (this Move move, Move other)
    {
        return
            (other == Move.Rock && move == Move.Paper) ||
            (other == Move.Paper && move == Move.Scissors) ||
            (other == Move.Scissors && move == Move.Rock);
    }

    public static int AsPoints (this Move move)
    {
        return move switch
        {
            Move.Rock => 1,
            Move.Paper => 2,
            Move.Scissors => 3,
        };
    }

    public static Move ToMovement (this Move move, Move outcome)
    {
        if (outcome == Move.Lose)
        {
            return move switch
            {
                Move.Rock     => Move.Scissors,
                Move.Paper    => Move.Rock,
                Move.Scissors => Move.Paper
            };
        }
        
        if (outcome == Move.Draw)
        {
            return move;
        }
        
        return move switch
        {
            Move.Scissors => Move.Rock,
            Move.Paper    => Move.Scissors,
            Move.Rock     => Move.Paper
        };
    }

    public static int ToMatchPoints (this Move move, Move other)
    {
        int matchPoints = 0;
        
        if (move.IsDraw (other) == true)
        {
            matchPoints = 3;
        }
        else if (move.IsWon (other) == false)
        {
            matchPoints = 6;
        }

        return matchPoints + other.AsPoints ();
    }
}