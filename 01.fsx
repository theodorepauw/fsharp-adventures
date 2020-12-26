open System.IO

let expenseReport = File.ReadLines(__SOURCE_DIRECTORY__ + "/inputs/01.txt") |> Seq.map int |> Seq.toList

let part1 =
    expenseReport 
    |> List.pick (fun a ->
        expenseReport |> List.tryPick (fun b -> if (a + b = 2020) then Some (a * b) else None))

let part2 =
    expenseReport
    |> List.pick (fun a -> 
        expenseReport |> List.tryPick (fun b ->
            expenseReport |> List.tryPick (fun c -> if (a+b+c = 2020) then Some (a*b*c) else None)))