open System.IO

let forest = File.ReadLines(__SOURCE_DIRECTORY__ + "/inputs/03.txt") 
            |> Seq.map (fun line ->
                line |> Seq.map (fun square -> if square = '#' then 1 else 0) |> Seq.toList)
            |> Seq.toList

let width = forest.[0].Length

let treesForSlope (dx, dy) =
    {0..dy..forest.Length-1} 
        |> Seq.fold (fun (trees: int, (x: int, y: int)) (y: int) -> (trees+forest.[y].[x%width], (x+dx, y+dy))) (0, (0, 0))
        |> fst

let p1 = treesForSlope (3, 1)
let p2 = [(1, 1); (3, 1); (5, 1); (7, 1); (1, 2)] |> List.fold (fun product slope -> product * (treesForSlope slope)) 1