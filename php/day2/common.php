<?php declare(strict_types=1);

    function points_on_move (string $move): int
    {
        return match (strtoupper ($move))
        {
            'A', 'X' => 1, // rock, lose
            'B', 'Y' => 2, // paper, draw
            'C', 'Z' => 3 // scissors, win
        };
    }

    function is_draw (int $opponent, int $ours): bool
    {
        return $opponent == $ours;
    }

    function is_won (int $opponent, int $ours): bool
    {
        return ($opponent == 1 && $ours == 2) ||
        ($opponent == 2 && $ours == 3) ||
        ($opponent == 3 && $ours == 1);
    }

    function outcome_to_move (int $outcome, int $opponentPoints)
    {
        if ($outcome == 1) // lose
        {
            return match ($opponentPoints)
            {
                1 => 3,
                2 => 1,
                3 => 2
            };
        }
        elseif ($outcome == 2) // draw
        {
            return $opponentPoints;
        }
        elseif ($outcome == 3) // win
        {
            return match ($opponentPoints)
            {
                1 => 2,
                2 => 3,
                3 => 1
            };
        }
    }

    function calculate_match_points (int $opponentPoints, int $ourPoints)
    {
        $matchPoints = 0;

        if (is_draw ($opponentPoints, $ourPoints) == true)
        {
            $matchPoints = 3;
        }
        else if (is_won ($opponentPoints, $ourPoints) == true)
        {
            $matchPoints = 6;
        }

        return $ourPoints + $matchPoints;
    }

    function calculate_move_value (string $opponent, string $ours)
    {
        $opponentPoints = points_on_move ($opponent);
        $ourPoints = points_on_move ($ours);

        return calculate_match_points ($opponentPoints, $ourPoints);
    }

    function calculate_expected_move_value (string $opponent, string $outcome)
    {
        $opponentPoints = points_on_move ($opponent);
        $outcomeValue = points_on_move ($outcome);
        $ourPoints = outcome_to_move ($outcomeValue, $opponentPoints);

        return calculate_match_points ($opponentPoints, $ourPoints);
    }

    function parse_input_file ()
    {
        $fileContents = file_get_contents ('input');
        $lineContents = explode ("\n", $fileContents);
        array_walk ($lineContents, function (&$value, $key) {
            $value = explode (' ', $value);
        });

        array_pop ($lineContents);

        return $lineContents;
    }