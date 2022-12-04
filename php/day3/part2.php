<?php declare(strict_types=1);
    include 'common.php';

    $rucksacks = get_rucksacks_from_file ();
    $result = 0;

    for ($i = 0; $i < count ($rucksacks); $i += 3)
    {
        $value = $rucksacks [$i + 0] [0] . $rucksacks [$i + 0] [1];
        $value2 = $rucksacks [$i + 1] [0] . $rucksacks [$i + 1] [1];
        $value3 = $rucksacks [$i + 2] [0] . $rucksacks [$i + 2] [1];

        foreach (str_split ($value) as $element)
        {
            if (
                str_contains ($value2, $element) == false ||
                str_contains ($value3, $element) == false)
                continue;

            $result += item_to_priority ($element);
            break;
        }
    }

    echo $result;