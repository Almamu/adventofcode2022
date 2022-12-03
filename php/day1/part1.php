<?php declare(strict_types=1);

    include "common.php";

    $elvesCaloriesSum = get_calories_sum ();

    rsort ($elvesCaloriesSum);
    echo array_shift ($elvesCaloriesSum);