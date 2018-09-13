using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VotingSystem1._2
{
    class Program
    {
        const byte all = 33;

        static void Main(string[] args)
        {
            string path = @"E:\CSharpAdvanced\VotingSystem\VotingSystem1.2\DataCollection.txt";
            List<string> kvorum = new List<string>();
            string[] toName =
         {    "Ахтер Исметов Чилев", "Божинел Василев Христов", "Валентина Маркова Френкева", "Веселин Валентинов Спасов",
             "Владимир Димитров Димитров", "Галин Пенчев Парашкевов", "Гюлвер Исмаил Хасан", "Джипо Николов Джипов", "Диана Добромирова Мирчева",
             "Елка Александрова Неделчева", "Емине Бейти Хасан", "Иво Борисов Димитров", "Илия Христов Илиев", "Калоян Руменов Монев",
             "Левент Али Апти", "Мануел Василев Чутурков", "Марина Петрова Христова", "Мариан Пламенов Иванов", "Милена Дачева Орешкова",
             "Митко Иванов Ханчев", "Надежда Радославова Димитрова", "Наско Стоилов Анастасов", "Радиана Ангелова Димитрова",
             "Рейхан Ридван Вели", "Светослав Теофилов Банков", "Стефан Димов Стефанов", "Стоян Димитров Ненчев", "Таня Петрова Тодорова",
             "Фатме Зелкиф Емин", "Фатме Селим Али","Хами Ибрахимов Хамиев", "Хасан Халилов Хасанов", "Янка Трифонова Георгиева"
        };
            List<string> take = toName.ToList();
            var gerb = new List<string>();
            var bsp = new List<string>();
            var dps = new List<string>();
            var reforma = new List<string>();
            var nezavisim = new List<string>();
            var kauza = new List<string>();

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
                    if (toName[person] == "Радиана Ангелова Димитрова" || toName[person] == "Валентина Маркова Френкева"
                        || toName[person] == "Галин Пенчев Парашкевов" || toName[person] == "Гюлвер Исмаил Хасан"
                        || toName[person] == "Мариан Пламенов Иванов" || toName[person] == "Марина Петрова Христова"
                        || toName[person] == "Надежда Радославова Димитрова" || toName[person] == "Наско Стоилов Анастасов"
                        || toName[person] == "Светослав Теофилов Банков" || toName[person] == "Стефан Димов Стефанов")
                    {
                        if (!delegateByPoliticians.ContainsKey("ГЕРБ"))
                        {
                            delegateByPoliticians.Add("ГЕРБ", new List<string>());
                            gerb.Add(toName[person]);
                        }
                        delegateByPoliticians["ГЕРБ"].Add(toName[person]);
                        gerb.Add(toName[person]);

                    }
                    else if (toName[person] == "Левент Али Апти" || toName[person] == "Ахтер Исметов Чилев"
                        || toName[person] == "Емине Бейти Хасан" || toName[person] == "Фатме Зелкиф Емин"
                        || toName[person] == "Хами Ибрахимов Хамиев" || toName[person] == "Хасан Халилов Хасанов")
                    {
                        if (!delegateByPoliticians.ContainsKey("Движение за права и свободи"))
                        {
                            delegateByPoliticians.Add("Движение за права и свободи", new List<string>());
                            dps.Add(toName[person]);

                        }
                        delegateByPoliticians["Движение за права и свободи"].Add(toName[person]);
                        dps.Add(toName[person]);


                    }
                    else if (toName[person] == "Елка Александрова Неделчева" || toName[person] == "Илия Христов Илиев"
                       || toName[person] == "Диана Добромирова Мирчева" || toName[person] == "Стоян Димитров Ненчев"
                       || toName[person] == "Таня Петрова Тодорова")
                    {
                        if (!delegateByPoliticians.ContainsKey("Българска социалистическа партия"))
                        {
                            delegateByPoliticians.Add("Българска социалистическа партия", new List<string>());
                            bsp.Add(toName[person]);

                        }
                        delegateByPoliticians["Българска социалистическа партия"].Add(toName[person]);
                        bsp.Add(toName[person]);

                    }
                    else if (toName[person] == "Митко Иванов Ханчев" || toName[person] == "Веселин Валентинов Спасов"
                      || toName[person] == "Джипо Николов Джипов" || toName[person] == "Иво Борисов Димитров"
                      || toName[person] == "Мануел Василев Чутурков")
                    {
                        if (!delegateByPoliticians.ContainsKey("Реформаторски блок"))
                        {
                            delegateByPoliticians.Add("Реформаторски блок", new List<string>());
                            reforma.Add(toName[person]);
                        }
                        delegateByPoliticians["Реформаторски блок"].Add(toName[person]);
                        reforma.Add(toName[person]);

                    }
                    else if (toName[person] == "Божинел Василев Христов" || toName[person] == "Владимир Димитров Димитров"
                        || toName[person] == "Калоян Руменов Монев")
                    {
                        if (!delegateByPoliticians.ContainsKey("Кауза Разград"))
                        {
                            delegateByPoliticians.Add("Кауза Разград", new List<string>());
                            kauza.Add(toName[person]);
                        }
                        delegateByPoliticians["Кауза Разград"].Add(toName[person]);
                        kauza.Add(toName[person]);


                    }
                    else if (toName[person] == "Фатме Селим Али" || toName[person] == "Милена Дачева Орешкова"
                        || toName[person] == "Рейхан Ридван Вели" || toName[person] == "Янка Трифонова Георгиева")
                    {
                        if (!delegateByPoliticians.ContainsKey("Независим общински съветник"))
                        {
                            delegateByPoliticians.Add("Независим общински съветник", new List<string>());
                            nezavisim.Add(toName[person]);
                        }
                        delegateByPoliticians["Независим общински съветник"].Add(toName[person]);
                        nezavisim.Add(toName[person]);

                    }
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
            Console.WriteLine($"Присъстват следните съветници => \n" + string.Join($"\n=>", kvorum));
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
            Dictionary<byte, string> invalidVotes = new Dictionary<byte, string>();

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
                        if (voting == "z")
                        {
                            positive.Add(a, kvorum[i]);
                            if (gerb.Contains(kvorum[i]))
                            {
                                gerbCountN[0]++;
                            }
                            if (bsp.Contains(kvorum[i]))
                            {
                                bspCountN[0]++;
                            }
                            if (dps.Contains(kvorum[i]))
                            {
                                dpsCountN[0]++;
                            }
                            if (reforma.Contains(kvorum[i]))
                            {
                                reformaCountN[0]++;
                            }
                            if (kauza.Contains(kvorum[i]))
                            {
                                kauzaCountN[0]++;
                            }
                            if (nezavisim.Contains(kvorum[i]))
                            {
                                freeCountN[0]++;
                            }
                            a++;
                        }
                        if (voting == "p")
                        {
                            negative.Add(b, kvorum[i]);
                            if (gerb.Contains(kvorum[i]))
                            {
                                gerbCountN[1]++;
                            }
                            if (bsp.Contains(kvorum[i]))
                            {
                                bspCountN[1]++;
                            }
                            if (dps.Contains(kvorum[i]))
                            {
                                dpsCountN[1]++;
                            }
                            if (reforma.Contains(kvorum[i]))
                            {
                                reformaCountN[1]++;
                            }
                            if (kauza.Contains(kvorum[i]))
                            {
                                kauzaCountN[1]++;
                            }
                            if (nezavisim.Contains(kvorum[i]))
                            {
                                freeCountN[1]++;
                            }
                            b++;
                        }
                        if (voting == "v")
                        {
                            neutral.Add(c, kvorum[i]);
                            if (gerb.Contains(kvorum[i]))
                            {
                                gerbCountN[2]++;
                            }
                            if (bsp.Contains(kvorum[i]))
                            {
                                bspCountN[2]++;
                            }
                            if (dps.Contains(kvorum[i]))
                            {
                                dpsCountN[2]++;
                            }
                            if (reforma.Contains(kvorum[i]))
                            {
                                reformaCountN[2]++;
                            }
                            if (kauza.Contains(kvorum[i]))
                            {
                                kauzaCountN[2]++;
                            }
                            if (nezavisim.Contains(kvorum[i]))
                            {
                                freeCountN[2]++;
                            }
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
                    var invalidV = invalidVotes.Count() == 0 ? 0 : invalidVotes.Count();

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
                    Console.WriteLine("GERB => " + gerbCountN[0]);
                    Console.WriteLine("BSP => " + bspCountN[0]);
                    Console.WriteLine("DPS => " + dpsCountN[0]);
                    Console.WriteLine("Reforma => " + reformaCountN[0]);
                    Console.WriteLine("Kauza => " + kauzaCountN[0]);
                    Console.WriteLine("Free => " + freeCountN[0]);
                    File.AppendAllText(path, "GERB => " + gerbCountN[0] + "\n");
                    File.AppendAllText(path, "BSP => " + bspCountN[0] + "\n");
                    File.AppendAllText(path, "DPS => " + dpsCountN[0] + "\n");
                    File.AppendAllText(path, "Reforma => " + reformaCountN[0] + "\n");
                    File.AppendAllText(path, "Kauza => " + kauzaCountN[0] + "\n");
                    File.AppendAllText(path, "Free => " + freeCountN[0] + "\n");
                    //
                    Console.WriteLine("Против");
                    File.AppendAllText(path, "Против");
                    Console.WriteLine("GERB => " + gerbCountN[1]);
                    Console.WriteLine("BSP => " + bspCountN[1]);
                    Console.WriteLine("DPS => " + dpsCountN[1]);
                    Console.WriteLine("Reforma => " + reformaCountN[1]);
                    Console.WriteLine("Kauza => " + kauzaCountN[1]);
                    Console.WriteLine("Free => " + freeCountN[1]);
                    File.AppendAllText(path, "GERB => " + gerbCountN[1] + "\n");
                    File.AppendAllText(path, "BSP => " + bspCountN[1] + "\n");
                    File.AppendAllText(path, "DPS => " + dpsCountN[1] + "\n");
                    File.AppendAllText(path, "Reforma => " + reformaCountN[1] + "\n");
                    File.AppendAllText(path, "Kauza => " + kauzaCountN[1] + "\n");
                    File.AppendAllText(path, "Free => " + freeCountN[1] + "\n");
                    //
                    Console.WriteLine("Въздържал се:");
                    File.AppendAllText(path, "Въздържал се:");

                    Console.WriteLine("GERB => " + gerbCountN[2]);
                    Console.WriteLine("BSP => " + bspCountN[2]);
                    Console.WriteLine("DPS => " + dpsCountN[2]);
                    Console.WriteLine("Reforma => " + reformaCountN[2]);
                    Console.WriteLine("Kauza => " + kauzaCountN[2]);
                    Console.WriteLine("Free => " + freeCountN[2]);
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
                    invalidVotes.Clear();
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
    }
}
