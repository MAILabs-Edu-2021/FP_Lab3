// Functional Programming: Lab 3
// Student: Maxim Guraevskiy

// Task 1

type TextTag =
    | Bold
    | Italic
    | Header1
    | Header2
    | Header3
    | Paragraph
    | List
    | ListItem

let tagName = function
    | Bold -> "b"
    | Italic -> "i"
    | Header1 -> "h1"
    | Header2 -> "h2"
    | Header3 -> "h3"
    | Paragraph -> "p"
    | List -> "ul"
    | ListItem -> "li"

let tagOfName = function
    | "b" -> Bold
    | "i" -> Italic
    | "h1" -> Header1
    | "h2" -> Header2
    | "h3" -> Header3
    | "p" -> Paragraph
    | "ul" -> List
    | "li" -> ListItem
    | _ -> failwith "Unknown tag"

type FormattedText =
    | Plain of string
    | Tagged of TextTag * FormattedText
    | Concat of FormattedText * FormattedText

// Task 2
// HTML
let encloseTag tn s = $"<{tn}>{s}</{tn}>"

let rec format : (FormattedText -> string) = function
    | Plain s -> s
    | Tagged (t, f) -> encloseTag (tagName t) (format f)
    | Concat (f, f') -> format f + format f'

// Task 3
let parse (x : string seq) : FormattedText = ...


// Task 4
let rec formatText : (FormattedText -> string) = function
    | Plain s -> s
    | Tagged (_, f) -> formatText f
    | Concat (f, f') -> formatText f + formatText f'

let strip : string -> string = parse >> formatText

// Task 5
// Distribution of sentence length in words
let analyze (x : string seq) =
    x
    |> Seq.map (fun s -> s.Split('.', '?', '!'))
    |> Seq.concat
    |> Seq.map (fun s -> s.Split(' ').Length)
    |> Seq.countBy id
