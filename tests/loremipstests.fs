module LoremIpsum.Tests

open System
open Xunit
open LoremIpsum

[<Fact>]
let ``getWords with capitalize set to Lowercase should return all words in lowercase`` () =
    let words = getWords { Capitalize = Lowercase; Count = Exact 5 }
    Assert.True(words |> List.forall(fun w -> Char.IsLower(w.[0])))

[<Fact>]
let ``getWords with capitalize set to All should return all words in uppercase`` () =
    let words = getWords { Capitalize = All; Count = Exact 5 }
    Assert.True(words |> List.forall(fun w -> Char.IsUpper(w.[0])))

[<Fact>]
let ``getWords with capitalize set to OnlyFirst should return only first word capitalized`` () =
    let words = getWords { Capitalize = OnlyFirst; Count = Exact 5 }
    words |> List.iteri(
        fun i w -> 
            match i with 
            | 0 -> Assert.True(Char.IsUpper(w.[0]))
            | _ -> Assert.True(Char.IsLower(w.[0]))
    )

[<Fact>]
let ``getWords with Exact amount should return exact amount of words`` () =
    let words = getWords { Capitalize = Lowercase; Count = Exact 10 }
    Assert.Equal(words.Length, 10)

[<Theory>]
[<InlineData(2,8)>]
[<InlineData(3,5)>]
[<InlineData(5,10)>]
[<InlineData(8,8)>]
let ``getWords with Arbitrary amount should return amount of words in the range`` (min, max) =
    let words = getWords { Capitalize = Lowercase; Count = Arbitrary (min,max) }
    Assert.InRange(words.Length, min, max)

[<Fact>]
let ``getWords with negative Arbitrary amounts should return 1 word`` () =
    let words = getWords { Capitalize = Lowercase; Count = Arbitrary (-5,-1) }
    Assert.Equal(1, words.Length)

[<Fact>]
let ``getSentence should return words in the range between 5 and 20`` () =
    let sentence = getSentence ()
    let words = sentence.Split([|".";" "|], StringSplitOptions.RemoveEmptyEntries)
    Assert.InRange(words.Length, 5, 20)

[<Fact>]
let ``getSentence should return first word capitalized`` () =
    let sentence = getSentence ()
    Assert.True(Char.IsUpper(sentence.[0]))

[<Fact>]
let ``getSentences should fail with error when n is negative number`` () =
    Assert.Throws<Exception>((fun () -> getSentences -10 |> ignore))

[<Theory>]
[<InlineData(1)>]
[<InlineData(2)>]
[<InlineData(3)>]
[<InlineData(4)>]
let ``getSentences should return exact amount of sentences separated by period`` (n) =
    let sentences = getSentences n
    let actual = sentences.Split([|"."|], StringSplitOptions.RemoveEmptyEntries)
    Assert.Equal(actual.Length, n)

[<Fact>]
let ``getParagraphs should fail with error when n is negative number`` () =
    Assert.Throws<Exception>((fun () -> getParagraphs -10 |> ignore))

[<Theory>]
[<InlineData(1)>]
[<InlineData(2)>]
[<InlineData(3)>]
[<InlineData(4)>]
let ``getParagraphs should return exact amount of paragraphs separated by the new line`` (n) =
    let paragraphs = getParagraphs n
    let actual = paragraphs.Split([|Environment.NewLine|], StringSplitOptions.RemoveEmptyEntries)
    Assert.Equal(actual.Length, n)