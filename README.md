# Lorem Ipsum generator
In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is available. It is also used to temporarily replace text in a process called greeking, which allows designers to consider the form of a webpage or publication, without the meaning of the text influencing the design.

## Usage: 

Generate exactly 10 words: </br>
`getWords { Capitalize = None; Count = Exact 10 }`
Sample output:
> ["duis"; "ex"; "proident"; "non"; "lorem"; "dolore"; "consequat"; "velit";
   "deserunt"; "aute"]

Generate random amount of words, capitalize first word: </br>
`getWords { Capitalize = OnlyFirst; Count = Arbitrary (5, 20) }`
Sample output:
> ["Occaecat"; "veniam"; "nostrud"; "dolore"; "cupidatat"; "magna"; "in";
   "consequat"; "consectetur"; "nisi"]

Generate random amount of words, capitalize all words: </br>
`getWords { Capitalize = All; Count = Arbitrary (5, 20) }`
Sample output:
> ["Enim"; "Ex"; "Enim"; "Incididunt"; "Elit"; "Aliquip"; "Pariatur"; "Ea";
   "Do"; "Irure"; "Sint"; "Labore"; "Elit"; "Consectetur"; "Reprehenderit"]

Generate a sentence with random words: </br>
`getSentence ()`
Sample output:
> "Ut in laboris mollit occaecat nulla cillum in adipiscing deserunt consectetur"

Generate 5 paragraphs with random sentences: </br>
`getParagraphs 5`
Sample output:
> "Ut laborum consectetur proident sunt ut tempor anim deserunt laboris tempor sit in sunt excepteur et. Eiusmod veniam fugiat ea proident excepteur magna sed anim. Ut ex nostrud laborum ullamco ex. Pariatur nulla eu eu tempor aliquip eu do deserunt nostrud amet ut dolore cupidatat. Dolor eiusmod consectetur eu consequat sunt"
