#load "./lib/loremipsum.fs"
open LoremIpsum

getWords { Capitalize = Lowercase; Count = Exact 10 }
getWords { Capitalize = OnlyFirst; Count = Arbitrary (5, 20) }
getWords { Capitalize = All; Count = Arbitrary (5, 20) }
getSentence ()
getSentences 5
getParagraphs 2