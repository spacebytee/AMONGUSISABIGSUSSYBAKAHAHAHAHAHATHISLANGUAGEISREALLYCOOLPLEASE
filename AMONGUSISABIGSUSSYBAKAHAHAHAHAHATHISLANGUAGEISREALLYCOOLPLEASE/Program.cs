using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AmongUsLanguage
{
    class Program
    {
        static string filename = "script";

        static Dictionary<string, int> values = new Dictionary<string, int>();

        static List<string> lines = new List<string>();

        static int currentLine = 0;
        static void Main(string[] args)
        {
            TextReader tr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @filename + ".auiabsbhhhhhtlircpuimldoioeppppppp");
            string code = tr.ReadLine();
            while (code != null)
            {
                lines.Add(code);
                code = tr.ReadLine();
            }
            while (currentLine < lines.Count)
            {
                RunLine(lines[currentLine]);
            
            }
        }
        static void RunLine(string code)
        {
            string[] args = code.Split(" ");
            if (code.Contains("GUYS I CAN VOUCH") && code.Contains(" IS "))
            {
                string player = args[4];
                int value = int.Parse(args[6]);

                if (values.ContainsKey(player)) {
                    values[player] = value;
                    currentLine += 1;
                    return;
                }

                values.Add(player, value);
            }
            if (code.Contains("CAN VOUCH GO AND TELL THEM COME ON"))
            {
                string player = args[0];
                if (values.ContainsKey(player))
                {
                    Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(values[player]) }));
                }
            }
            if (code.Contains("IS JUST LIKE"))
            {
                string player = args[0];
                string sussyplayer = args[4];


                
                if (values.ContainsKey(player) && values.ContainsKey(sussyplayer))
                {
                    values[player] = values[sussyplayer];
                    currentLine += 1;
                    return;
                } else if (values.ContainsKey(sussyplayer))
                {
                    values.Add(player, values[sussyplayer]);
                }
                
            }
            if (code.Contains("IF ITS NOT ") && code.Contains(" THEN VOTE ME"))
            {
                string player = args[3];

                if (values.ContainsKey(player))
                {
                    if (values[player] == 0)
                    {
                        currentLine += 1;
                    }
                }
            }
            if (code.Contains("IDK WHAT ") && code.Contains(" IS BUT ITS BETWEEN ") && code.Contains(" AND "))
            {
                Random ran = new Random();
                string player = args[2];
                int first = int.Parse(args[7]);
                int second = int.Parse(args[9]);
                int value = ran.Next(first, second + 1);

                if (values.ContainsKey(player))
                {
                    values[player] = value;
                    currentLine += 1;
                    return;
                }
                values.Add(player, value);
            }
            if (code.Contains("WAS THE IMPOSTOR"))
            {
                if (values[args[0]] != 0) {
                    currentLine += lines.Count;
                }    
            }
            if (code.Contains("GOES UP"))
            {
                string player = args[0];
                if (values.ContainsKey(player))
                {
                    values[player] += 1;
                }
            }
            if (code.Contains("GOES DOWN"))
            {
                string player = args[0];
                if (values.ContainsKey(player))
                {
                    values[player] -= 1;
                }
            }
            currentLine += 1;
        }
    }
}
