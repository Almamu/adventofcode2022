<?php declare(strict_types=1);

    include 'common.php';

    $rucksacks = get_rucksacks_from_file ();
    $result = 0;

    foreach ($rucksacks as $sack)
    {
        $elements = find_common_elements ($sack);
        array_walk ($elements, function (&$value) {
            $value = item_to_priority ($value);
        });
        $result += array_sum ($elements);
    }

    echo $result;