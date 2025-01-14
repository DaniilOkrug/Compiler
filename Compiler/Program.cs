﻿// See https://aka.ms/new-console-template for more information

using Compiler.SyntaxAnalyser;
using Newtonsoft.Json;

var program = @"2a 4.2.0
routine gcd (a: integer, b: integer): integer is
    if a > b then
//some comment
       var small := b;
    else
       var small := a;
    end;
    for i in 1 .. (small + 1) loop is
        if (a % i = 0) and (b % i = 0) then
          var ans := i;
        end;
    return ans;";

// program = @"2a int";


foreach (var tok in SyntaxAnalyser.FinalStateAutomata(program))
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{tok.GetType().Name}\t");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{tok.TokenId}\t");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"{JsonConvert.SerializeObject(tok)}");
}