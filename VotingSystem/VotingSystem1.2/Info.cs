using System;
using System.IO;

class Info
{
    string text = File.ReadAllText(@"E:\CSharpAdvanced\VotingSystem1.2\VotingSystem\VotingSystem1.2\Information.txt");

    public Info()
    {
        Console.WriteLine(text);
    }
}

