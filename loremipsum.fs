module LoremIpsum

open System
open System.Collections.Generic

[<Literal>]
let loremipsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."

type CapitalizeMode =
    | OnlyFirst
    | All
    | None

type WordCount = 
    | Arbitrary of min:int * max:int
    | Exact of int

type LoremIpsumOption = {
    Capitalize: CapitalizeMode
    Count: WordCount
}

// ================================================
// Utils
// ================================================
let private memoize (f: 'a -> 'b) =
    // Storage for the calculated result
    let cache = new Dictionary<_, _>()
    // Check if it's in the cache or not
    (fun x ->
        match cache.TryGetValue(x) with
        | true, cachedValue -> cachedValue
        | _ -> 
            let result = f x
            cache.Add(x, result)
            result)

let private split (text : string) = 
    text.Split([|",";".";" "|], StringSplitOptions.RemoveEmptyEntries)

let private getRandom (min, max) = 
    let getRandomUtil (min, max) = 
        let rnd = Random()
        (min, max) |> rnd.Next

    let newMin = if min <= 0 then 1 else min
    let newMax = if max < min then min else max
    getRandomUtil (newMin, newMax)

let private stringToCase fn (str: string) =
    str 
    |> Seq.mapi (fun i c -> match i with | 0 -> (fn c) | _ -> c)
    |> String.Concat

let private upper = stringToCase (fun c -> Char.ToUpperInvariant(c))
let private lower = stringToCase (fun c -> Char.ToLowerInvariant(c))

// ================================================
// Implementation
// ================================================
let loremIpsumWords = 
    loremipsum
    |> memoize (fun x -> split x)

let private getRandomLoremIpsum =
    let rnd = Random()
    fun () -> loremIpsumWords.[rnd.Next(loremIpsumWords.Length)] |> lower

let getWords option =
    let rec getWordsUtil acc n = 
        match n with
        | 0 -> acc
        | _ -> getWordsUtil (getRandomLoremIpsum()::acc) (n - 1)
    
    match (option.Capitalize, option.Count) with
    | (OnlyFirst, Arbitrary (min, max)) -> 
        getWordsUtil [] (getRandom (min, max))
        |> function
        | [] -> []
        | x::xs -> (upper x) :: xs
    | (All, Arbitrary (min, max)) -> getWordsUtil [] (getRandom (min, max)) |> List.map upper
    | (None, Arbitrary (min, max)) -> getWordsUtil [] (getRandom (min, max))
    | (OnlyFirst, Exact count) -> 
        getWordsUtil [] count
        |> function
        | [] -> []
        | x::xs -> (upper x) :: xs
    | (All, Exact count) -> getWordsUtil [] count |> List.map upper
    | (None, Exact count) -> getWordsUtil [] count

let getSentence = 
    fun () -> getWords { Capitalize = OnlyFirst; Count = Arbitrary (5, 20) } |> String.concat " "

let getParagraphs n = 
    if n <= 0 then failwith "n should be a positive number, more than zero."
    seq { for _ in 1..n -> getSentence () }
    |> List.ofSeq 
    |> String.concat ". "