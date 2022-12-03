<?php declare(strict_types=1);

    function get_calories_sum (): array
    {
        $fileContents = file_get_contents ("input");
        $lines = explode ("\n", $fileContents);
        $elvesCaloriesSum = array ();
        $currentSum = 0;

        foreach ($lines as $line)
        {
            $line = trim ($line);

            if ($line == "")
            {
                $elvesCaloriesSum [] = $currentSum;
                $currentSum = 0;
                continue;
            }

            $currentSum += intval ($line);
        }

        rsort ($elvesCaloriesSum);
        return $elvesCaloriesSum;
    }
