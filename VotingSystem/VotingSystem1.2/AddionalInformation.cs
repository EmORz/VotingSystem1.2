using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


class AddionalInformation
{
    string text = File.ReadAllText(@"E:\CSharpAdvanced\VotingSystem1.2\VotingSystem\VotingSystem1.2\ExtraInformationtxt.txt");

    public AddionalInformation()
    {
        Console.WriteLine(text);
    }

}

