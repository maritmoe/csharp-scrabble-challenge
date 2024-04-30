// See https://aka.ms/new-console-template for more information
using csharp_scrabble_challenge.Main;

// The following will first give triple letter score to 'e' and then double the total word score => 16
Scrabble s = new Scrabble("{str[e]et}");
Console.WriteLine(s.score());
