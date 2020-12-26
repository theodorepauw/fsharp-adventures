open System.IO
open System

let passwords = File.ReadLines(__SOURCE_DIRECTORY__ + "/inputs/02.txt")
                |> Seq.map (fun s ->
                    let parts = s.Split( Seq.toArray <|"-: ", StringSplitOptions.RemoveEmptyEntries)
                    (int parts.[0], int parts.[1], char parts.[2], parts.[3]))

let part1 = passwords
            |> Seq.filter (fun (min, max, c, s) ->
                let appearances = s |> Seq.filter ((=) c) |> Seq.length
                appearances >= min && appearances <= max)
            |> Seq.length

let part2 = passwords
            |> Seq.filter (fun (pos1, pos2, c, s) ->
                (s.[pos1-1]=c) <> (s.[pos2-1]=c))
            |> Seq.length