using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VotingSystem1._2
{
    class Program
    {
        const byte all = 33;
        const string path = @"E:\CSharpAdvanced\VotingSystem1.2\VotingSystem\VotingSystem1.2\DataCollection.txt";
        
        
        static void Main(string[] args)
        {
            GERB gerbb = new GERB();
            BSP bspp = new BSP();
            DPS dpss = new DPS();
            KauzaRz kauzaa = new KauzaRz();
            Free freee = new Free();
            ReformBlog reformBlogg = new ReformBlog();
            //
            Console.WriteLine("Искате ли да започнете работа със Системата?");

            Console.WriteLine("за да започнете работа натиснете =>       0");
            Console.WriteLine("за повече информация натиснете   =>       1 ");
            Console.WriteLine("за изход от Системата натиснете  =>       2 ");
            var enter = Console.ReadLine();
            if (enter == "0")
            {
                PrintInfoForProgram();

                var allCouncilMan = gerbb.ListCol().Concat(bspp.ListCol().Concat(dpss.ListCol().Concat(kauzaa.ListCol().Concat(freee.ListCol().Concat(reformBlogg.ListCol())))));
                string[] allCouncilArr = allCouncilMan.ToArray();
                //
                List<string> kvorum = new List<string>();
                string[] toName = allCouncilArr;
                List<string> take = toName.ToList();
                //
                var gerb = gerbb.ListCol();
                var bsp = bspp.ListCol();
                var dps = dpss.ListCol();
                var reforma = reformBlogg.ListCol();
                var nezavisim = freee.ListCol();
                var kauza = kauzaa.ListCol();

                Dictionary<string, List<string>> delegateByPoliticians = new Dictionary<string, List<string>>();
                byte count = 0;
                //Kvorum => string za potvyrjdenie => Tuk
                for (int person = 0; person < all; person++)
                {
                    Console.Write(toName[person] + " => ");
                    var checking = Console.ReadLine();
                    Console.WriteLine(checking);
                    File.AppendAllText(path, "Кворум:");

                    if (checking == "tuk")
                    {
                        count++;
                        kvorum.Add($"{toName[person]}");
                        File.AppendAllText(path, toName[person]);
                        take.Remove(toName[person]);
                        //
                        TakeInfoForPartAndPerson(gerbb, bspp, dpss, kauzaa, freee, reformBlogg, toName, delegateByPoliticians, person);
                    }
                }
                var result = kvorum.Count > 16 ? "Има кворум" : $"Няма кворум, нужни са още/поне {16 - kvorum.Count} гласа!";
                File.AppendAllText(path, result);
                Console.WriteLine("..................................................");
                Console.WriteLine("Присъстват по партийни групи:");
                File.AppendAllText(path, "Присъстват по партийни групи:");

                var tempC = 0;
                foreach (var party in delegateByPoliticians)
                {
                    Console.WriteLine(party.Key);
                    File.AppendAllText(path, party.Key);

                    foreach (var person in party.Value)
                    {
                        tempC++;
                        Console.WriteLine($"{tempC}. " + person);
                        File.AppendAllText(path, $"{tempC}. " + person + "\n");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("..................................................");
                Console.WriteLine($"Гласували общо: {count}");
                File.AppendAllText(path, $"Гласували общо: {count}" + "\n");

                Console.WriteLine($"{result}");
                File.AppendAllText(path, $"{result}" + "\n");
                Console.WriteLine($"Присъстват следните съветници:");
                for (int i = 0; i < kvorum.Count; i++)
                {
                    Console.WriteLine($"{i} => {kvorum[i]}");
                }
                File.AppendAllText(path, $"Присъстват следните съветници => \n" + string.Join($"\n=>", kvorum));
                Console.WriteLine($"Отсъстват следните съветници =>");
                File.AppendAllText(path, $"Отсъстват следните съветници =>");
                var countMising = 1;
                for (int i = 0; i < take.Count; i++)
                {
                    Console.WriteLine($"{countMising++} => {take[i]}");
                    File.AppendAllText(path, $"{countMising++} => {take[i]}" + "\n");

                }
                Console.WriteLine("..................................................");
                Dictionary<byte, string> positive = new Dictionary<byte, string>();
                Dictionary<byte, string> negative = new Dictionary<byte, string>();
                Dictionary<byte, string> neutral = new Dictionary<byte, string>();

                byte a = 1; byte b = 1; byte c = 1; ;


                if (kvorum.Count > 16)
                {
                    Console.WriteLine("Заседанието има кворум и докладните могат да се гласуват!");
                    File.AppendAllText(path, "Заседанието има кворум и докладните могат да се гласуват!" + "\n");

                    //работи се с лист от кворума => приема се до доказване на противното, 
                    //че за да се приеме докладна трябва да има >50% от гласовете на делегатите.
                    Console.WriteLine("Желате ли да започнете гласуването? Yes/No" + $"\nИмате кворум от => {kvorum.Count} делегата!");
                    File.AppendAllText(path, "Желате ли да започнете гласуването? Yes/No" + $"\nИмате кворум от => {kvorum.Count} делегата!" + "\n");


                    var askAction = Console.ReadLine();

                    var gerbCountN = new byte[3] { 0, 0, 0 };
                    var bspCountN = new byte[3] { 0, 0, 0 };
                    var dpsCountN = new byte[3] { 0, 0, 0 };
                    var reformaCountN = new byte[3] { 0, 0, 0 };
                    var kauzaCountN = new byte[3] { 0, 0, 0 };
                    var freeCountN = new byte[3] { 0, 0, 0 };

                    while (askAction != "No")
                    {
                        for (int i = 0; i < kvorum.Count; i++)
                        {
                            Console.Write(kvorum[i] + " => ");
                            var voting = Console.ReadLine();
                            Console.WriteLine(voting);
                            byte n = 0;
                            if (voting == "z")
                            {
                                positive.Add(a, kvorum[i]);

                                GetV(kvorum, gerb, gerbCountN, i);
                                GetV(kvorum, bsp, bspCountN, i);
                                GetV(kvorum, dps, dpsCountN, i);
                                GetV(kvorum, reforma, reformaCountN, i);
                                GetV(kvorum, nezavisim, freeCountN, i);
                                GetV(kvorum, kauza, kauzaCountN, i);
                                a++;
                            }
                            if (voting == "p")
                            {
                                negative.Add(b, kvorum[i]);
                                GetV2(kvorum, gerb, gerbCountN, i);
                                GetV2(kvorum, bsp, bspCountN, i);
                                GetV2(kvorum, dps, dpsCountN, i);
                                GetV2(kvorum, nezavisim, freeCountN, i);
                                GetV2(kvorum, reforma, reformaCountN, i);
                                GetV2(kvorum, kauza, kauzaCountN, i);
                                b++;
                            }
                            if (voting == "v")
                            {
                                neutral.Add(c, kvorum[i]);
                                GetV3(kvorum, gerb, gerbCountN, i);
                                GetV3(kvorum, bsp, bspCountN, i);
                                GetV3(kvorum, dps, dpsCountN, i);
                                GetV3(kvorum, nezavisim, freeCountN, i);
                                GetV3(kvorum, reforma, reformaCountN, i);
                                GetV3(kvorum, kauza, kauzaCountN, i);
                                c++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        Console.WriteLine("..................................................");
                        Console.WriteLine("Резултат от гласуването =>");

                        Console.WriteLine("За");
                        File.AppendAllText(path, "За" + "\n");

                        if (positive.Count() != 0)
                        {
                            foreach (var za in positive)
                            {
                                Console.Write($"{za.Key} поредност на вота => ");
                                foreach (var item in za.Value)
                                {
                                    Console.Write($"{item}");
                                    File.AppendAllText(path, $"{item}");

                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.Write(" => " + 0);
                        }
                        Console.WriteLine("Против");
                        File.AppendAllText(path, "Против" + "\n");

                        if (negative.Count() != 0)
                        {
                            foreach (var protiv in negative)
                            {
                                Console.Write($"{protiv.Key} поредност на вота => ");
                                foreach (var item in protiv.Value)
                                {
                                    Console.Write(item);
                                    File.AppendAllText(path, item.ToString());

                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.Write(" => " + 0);
                        }
                        Console.WriteLine("Въздържал се");
                        File.AppendAllText(path, "Въздържал се" + "\n");

                        if (neutral.Count() != 0)
                        {
                            foreach (var pass in neutral)
                            {
                                Console.Write($"{pass.Key} поредност на вота => ");
                                foreach (var item in pass.Value)
                                {
                                    Console.Write(item);
                                    File.AppendAllText(path, item.ToString());

                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.Write(" => " + 0);
                        }
                        Console.WriteLine("..................................................");
                        var isOk = positive.Count() > kvorum.Count / 2;
                        var p = positive.Count() == 0 ? 0 : positive.Count();
                        var nega = negative.Count() == 0 ? 0 : negative.Count();
                        var neutr = neutral.Count() == 0 ? 0 : neutral.Count();

                        Console.WriteLine("..................................................");
                        if (isOk)
                        {
                            Console.WriteLine("Докладната се приема!");
                            File.AppendAllText(path, "Докладната се приема!");
                            Console.WriteLine(p + " ЗА");
                            File.AppendAllText(path, p + " ЗА\n");
                            Console.WriteLine(nega + " Против");
                            File.AppendAllText(path, nega + " Против\n");
                            Console.WriteLine(neutr + " Въздържал се");
                            File.AppendAllText(path, neutr + " Въздържал се\n");

                        }
                        else
                        {
                            Console.WriteLine("Докладната се отхвърля!");
                            File.AppendAllText(path, "Докладната се отхвърля!\n");

                            Console.WriteLine(p + " ЗА");
                            File.AppendAllText(path, p + " ЗА\n");
                            Console.WriteLine(nega + " Против");
                            File.AppendAllText(path, nega + " Против\n");
                            Console.WriteLine(neutr + " Въздържал се");
                            File.AppendAllText(path, neutr + " Въздържал се\n");

                        }
                        Console.WriteLine("..................................................");
                        Console.WriteLine("По политически групи:");
                        File.AppendAllText(path, "По политически групи:\n");
                        Console.WriteLine("..................................................");
                        Console.WriteLine("За");
                        File.AppendAllText(path, "За\n");
                        
                        Print(gerbCountN[0], bspCountN[0], dpsCountN[0], reformaCountN[0], kauzaCountN[0], freeCountN[0]);
                        File.AppendAllText(path, "GERB => " + gerbCountN[0] + "\n");
                        File.AppendAllText(path, "BSP => " + bspCountN[0] + "\n");
                        File.AppendAllText(path, "DPS => " + dpsCountN[0] + "\n");
                        File.AppendAllText(path, "Reforma => " + reformaCountN[0] + "\n");
                        File.AppendAllText(path, "Kauza => " + kauzaCountN[0] + "\n");
                        File.AppendAllText(path, "Free => " + freeCountN[0] + "\n");
                        //
                        Console.WriteLine("Против");
                        File.AppendAllText(path, "Против");
                        Print(gerbCountN[1], bspCountN[0], dpsCountN[1], reformaCountN[1], kauzaCountN[1], freeCountN[1]);

                        File.AppendAllText(path, "GERB => " + gerbCountN[1] + "\n");
                        File.AppendAllText(path, "BSP => " + bspCountN[1] + "\n");
                        File.AppendAllText(path, "DPS => " + dpsCountN[1] + "\n");
                        File.AppendAllText(path, "Reforma => " + reformaCountN[1] + "\n");
                        File.AppendAllText(path, "Kauza => " + kauzaCountN[1] + "\n");
                        File.AppendAllText(path, "Free => " + freeCountN[1] + "\n");
                        //
                        Console.WriteLine("Въздържал се:");
                        File.AppendAllText(path, "Въздържал се:");
                        Print(gerbCountN[2], bspCountN[2], dpsCountN[2], reformaCountN[2], kauzaCountN[2], freeCountN[2]);
                        File.AppendAllText(path, "GERB => " + gerbCountN[2] + "\n");
                        File.AppendAllText(path, "BSP => " + bspCountN[2] + "\n");
                        File.AppendAllText(path, "DPS => " + dpsCountN[2] + "\n");
                        File.AppendAllText(path, "Reforma => " + reformaCountN[2] + "\n");
                        File.AppendAllText(path, "Kauza => " + kauzaCountN[2] + "\n");
                        File.AppendAllText(path, "Free => " + freeCountN[2] + "\n");
                        Console.WriteLine("..................................................");
                        File.AppendAllText(path, DateTime.Now.ToString() + "\n");
                        Console.ReadKey();
                        Console.WriteLine("Желате ли да започнете ново гласуване ? Yes/No");

                        //зануляване на стойностите.
                        positive.Clear();
                        neutral.Clear();
                        negative.Clear();
                        for (int i = 0; i < gerbCountN.Length; i++)
                        {
                            gerbCountN[i] = 0;
                        }
                        for (int i = 0; i < bspCountN.Length; i++)
                        {
                            bspCountN[i] = 0;
                        }
                        for (int i = 0; i < dpsCountN.Length; i++)
                        {
                            dpsCountN[i] = 0;
                        }
                        for (int i = 0; i < reformaCountN.Length; i++)
                        {
                            reformaCountN[i] = 0;
                        }
                        for (int i = 0; i < kauzaCountN.Length; i++)
                        {
                            kauzaCountN[i] = 0;
                        }
                        for (int i = 0; i < freeCountN.Length; i++)
                        {
                            freeCountN[i] = 0;
                        }
                        askAction = Console.ReadLine();
                    }
                }
                Console.ReadKey();
            }
            if (enter == "1")
            {
                PrintAddInfoForProgram();
            }
            if (enter == "2")
            {
                Console.WriteLine("Благодарим Ви, че използвате Системата!");
            }  
        }

        private static void GetV3(List<string> kvorum, List<string> gerb, byte[] gerbCountN, int i)
        {
            if (gerb.Contains(kvorum[i]))
            {
                gerbCountN[2]++;
            }
        }
        private static void GetV2(List<string> kvorum, List<string> gerb, byte[] gerbCountN, int i)
        {
            if (gerb.Contains(kvorum[i]))
            {
                gerbCountN[1]++;
            }
        }
        private static void GetV(List<string> kvorum, List<string> gerb, byte[] gerbCountN, int i)
        {
            if (gerb.Contains(kvorum[i]))
            {
                gerbCountN[0]++;
            }
        }
        private static void Print(byte gerbCountN, byte bspCountN, byte dpsCountN, byte reformaCountN,byte kauzaCountN, byte freeCountN)
        {
            Console.WriteLine("GERB => " + gerbCountN);
            Console.WriteLine("BSP => " + bspCountN);
            Console.WriteLine("DPS => " + dpsCountN);
            Console.WriteLine("Reforma => " + reformaCountN);
            Console.WriteLine("Kauza => " + kauzaCountN);
            Console.WriteLine("Free => " + freeCountN);
        }
        private static void GetVote(List<string> kvorum, List<string> data, byte[] f, int i, byte n)
        {
            if (data.Contains(kvorum[i]))
            {
                f[n]++;
            }
        }
        private static void TakeInfoForPartAndPerson(GERB gerbb, BSP bspp, DPS dpss, KauzaRz kauzaa, Free freee, ReformBlog reformBlogg, string[] toName, Dictionary<string, List<string>> delegateByPoliticians, int person)
        {
            if (gerbb.ListCol().Contains(toName[person]))
            {
                if (!delegateByPoliticians.ContainsKey("ГЕРБ"))
                {
                    delegateByPoliticians.Add("ГЕРБ", new List<string>());
                }
                delegateByPoliticians["ГЕРБ"].Add(toName[person]);
            }
            else if (dpss.ListCol().Contains(toName[person]))
            {
                if (!delegateByPoliticians.ContainsKey("Движение за права и свободи"))
                {
                    delegateByPoliticians.Add("Движение за права и свободи", new List<string>());
                }
                delegateByPoliticians["Движение за права и свободи"].Add(toName[person]);
            }
            else if (bspp.ListCol().Contains(toName[person]))
            {
                if (!delegateByPoliticians.ContainsKey("Българска социалистическа партия"))
                {
                    delegateByPoliticians.Add("Българска социалистическа партия", new List<string>());
                }
                delegateByPoliticians["Българска социалистическа партия"].Add(toName[person]);
            }
            else if (reformBlogg.ListCol().Contains(toName[person]))
            {
                if (!delegateByPoliticians.ContainsKey("Реформаторски блок"))
                {
                    delegateByPoliticians.Add("Реформаторски блок", new List<string>());
                }
                delegateByPoliticians["Реформаторски блок"].Add(toName[person]);
            }
            else if (kauzaa.ListCol().Contains(toName[person]))
            {
                if (!delegateByPoliticians.ContainsKey("Кауза Разград"))
                {
                    delegateByPoliticians.Add("Кауза Разград", new List<string>());
                }
                delegateByPoliticians["Кауза Разград"].Add(toName[person]);
            }
            else if (freee.ListCol().Contains(toName[person]))
            {
                if (!delegateByPoliticians.ContainsKey("Независим общински съветник"))
                {
                    delegateByPoliticians.Add("Независим общински съветник", new List<string>());
                }
                delegateByPoliticians["Независим общински съветник"].Add(toName[person]);
            }
        }
        public static string PathToStorageFile()
        {
            return @"E:\CSharpAdvanced\VotingSystem\VotingSystem1.2\DataCollection.txt";
        }
        private static void PrintInfoForProgram()
        {
            var printInfo = new Info();
            Console.WriteLine(printInfo);
        }
        private static void PrintAddInfoForProgram()
        {
            var printInfo = new AddionalInformation();
            Console.WriteLine(printInfo);
        }
    }
}
