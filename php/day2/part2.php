<?php declare(strict_types=1);
    include "common.php";

    $inputs = parse_input_file ();

    echo array_reduce (
        $inputs,
        fn ($carry, $item) =>
            $carry + calculate_expected_move_value ($item [0], $item [1])
    );