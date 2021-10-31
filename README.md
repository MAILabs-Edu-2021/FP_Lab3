# Functional Programming: Lab 3

## Text Processing in Functional Style using Lists/Sequences/Trees

**Objective:** Learning how to solve relatively complex real-life problems of text processing using lazy sequences and abstract data types.

> When working on this lab, you may want to keep in mind the priciples of [Domain Driven Design](https://en.wikipedia.org/wiki/Domain-driven_design) - an approach when you model entities in your program (classes, types) according to the entities in the problem domain. Functional programming is very well suited for Domain Driven Design! Look at [this page](https://fsharpforfunandprofit.com/ddd/) for an excellent intro.

### Task: 
 1. *[3 points]* Design an abstract data type to represent formatted text that consists of paragraphs, bullet-item lists, bold/italic text, and headers (levels 1 through 3). 
 2. *[10 points]* Write a function that renders the given data structure into one of the following formats (use formula (N-1)%3+1 to find out the one you need to use):
     1. Markdown
     2. HTML
     3. LaTeX 
 3. *[20 points]* Write a function that takes input file in the given format and produces its internal representation (use 1 for odd N, 2 for even):
     1. XHTML with tags `<b>`, `<li>`, `<ul>`, `<i>`, `<h1>`, `<h2>`, `<h3>` (plus corresponding closing tags)
     2. Simplified version of Markdown
 4. *[2 points]* Write a function that strips out all formatting and produces plain text 
 5. *[15 points]* Write a function that calculates for a given (relatively large) plain text (use (N-1)%4+1 formula to find out your number):
     1. Bigram frequencies (eg. frequencies with which two words appear together in text, one next to the other)
     2. A list of main protagonists, which are defined as words that appear more than 3 times with capital letter inside a sentence. Then for all of them determine their likelihood to appear in the same sentence.
     3. Distribution of sentence length in words
     4. For each word - the distribution of its positions inside the sentence (first word - 0).

To get sample text files, feel free to use books from [Project Gutenberg](http://gutenberg.org), for example:
   - Alice's Adventures in Wonderland: http://www.gutenberg.org/files/11/11-0.txt
   - War and Peace: http://www.gutenberg.org/files/2600/2600-0.txt
   - Sherlok Holmes: http://www.gutenberg.org/cache/epub/1661/pg1661.txt

To download text file from the internet, use the following function:

```fsharp
let http (url:string) =
   let rq = WebRequest.Create(url)
   use res = rq.GetResponse()
   use rd = new StreamReader(res.GetResponseStream())
   rd.ReadToEnd()
```

Your programming style will also be evaluated. Try to use lazy sequences when possible to allow for large file processing 
(especially in #5). Use abstract data type / tree for in-memory representation of formatted document. Implement some ideas from DDD.

Good luck!
