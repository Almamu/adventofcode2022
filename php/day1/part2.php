<?php declare(strict_types=1);
    include "common.php";

    $elvesCaloriesSum = get_calories_sum ();
    $topThree = array ();

    for ($i = 0; $i < 3; $i ++)
        $topThree [] = $elvesCaloriesSum [$i];


    echo array_sum ($topThree);