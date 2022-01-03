#load "loremipsum.fs"
open LoremIpsum

getWords { Capitalize = None; Count = Exact 10 }
getWords { Capitalize = OnlyFirst; Count = Arbitrary (5, 20) }
getWords { Capitalize = All; Count = Arbitrary (5, 20) }
getSentence ()
getParagraphs 5