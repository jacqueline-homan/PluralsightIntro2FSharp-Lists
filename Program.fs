
// This is also called an un-typed List
let empty = []

let intList = [12;4;92;30]
printfn "%A" intList

let addItem xs x = x:: xs

let newIntList = addItem intList 42
printfn "%A" newIntList
printfn "%A" (["hey you"; "get off"]@["of my"; "cloud"])
printfn "%A" newIntList.Head
printfn "%A" newIntList.Tail
printfn "%A" newIntList.Tail.Tail.Head
printfn "%A" newIntList.Length

//You can iterate over a list to output the elements of a
//list in a non-array format like so:
for i in newIntList do //This is like iterating over a list using for each in C#
    printfn "%A" i

//Checking to see if a list is empty is easy. But notice that the
//type inference does not infer the list type without using
//type annotation:
let rec listLength(l: 'a list) =
    if l.IsEmpty then 0
        else 1 + (listLength l.Tail)
printfn "%d" (listLength newIntList)

let rec listLength' l =
    match l with
    | [] -> 0
    | x :: xs -> 1 + (listLength' xs)
printfn "%d" (listLength' newIntList)

let rec listLength'' = function
    | [] -> 0
    | _ :: xs -> 1 + (listLength' xs)
printfn "%d" (listLength' newIntList)

///Sequences
let output x = printfn "%A" x

let ints = [7..13]
output ints

let oddVals = [1..2..20]
output oddVals
// A different way of writing the code in lines 48-49:
let values step max = [1..step..max]
output (values 2 20)

let ints' = seq {7..13}
output ints'

//Prints out the squares of numbers 7 to 13 in a list
output[for x in 7..13 -> x * x]

//Returning a tuple
output[for x in 7..13 -> x, x * x]

output[for x in 7..13 -> 
                        printfn "Return value now"
                        x, x * x]

let yieldedValues = 
    seq {
        yield 3;
        yield 42;
        for i in 1..3 do
            yield i
        yield! [5;7;8]
    }
output (List.ofSeq yieldedValues)

let yieldedStrings =
    seq {
        yield "this";
        yield "that";
        }
output (List.ofSeq yieldedStrings)

//[<EntryPoint>]
//let main argv = 
//    printfn "%A" argv
//    0 // return an integer exit code

