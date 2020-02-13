using System.Collections.Generic;
using System.Net.Mime;
using McMaster.Extensions.CommandLineUtils;
using System.Globalization;
using System;

namespace cli_Challenge
{
    [HelpOption("--hlp")]
    [Subcommand(
        typeof(UpperCase),
        typeof(LowerCase),
        typeof(Capital),
        typeof(Obfuscator)
    )]
    class Program
    {
        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }

        [Command(Description = "Command to uppercase string", Name = "uppercase")]
        class UpperCase
        {
            [Argument(0)]
            public string text { get; set; }
            public void OnExecute(CommandLineApplication app)
            {
                Console.WriteLine($"{text.ToUpper()}");
            }
        }
        [Command(Description = "Command to lowercase string", Name = "lowercase")]
        class LowerCase
        {
            [Argument(0)]
            public string text { get; set; }
            public void OnExecute(CommandLineApplication app)
            {
                Console.WriteLine($"{text.ToLower()}");
            }
        }

        [Command(Description = "Command to capitalize string", Name= "capitalize")]
        class Capital
        {
            [Argument(0)]
            public string text { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                Console.WriteLine($"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text)}");
            }
        }

        [Command(Description = "Command to obfuscator", Name= "obfuscator")]
        class Obfuscator
        {
            [Argument(0)]
            public string text { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                char[] b = text.ToCharArray();
                List<string> c = new List<string>();

                foreach(var d in c)
                {
                    c.Add($"&#{Convert.ToString(Convert.ToInt32(b))}");
                }

                Console.WriteLine(String.Join(";", c));
            }
        }
        // class numberTwo
        // {
        //     public static int Arithmetic(){

        //     }
        // }

        // class numberThree
        // {
        //     public static Palindrome(string a){
        //         string rev;
        //         char[] word = a.ToCharArray();
        //         Array.Reverse(word);

        //         rev = new string(word);
        //         bool palindrom = a.Equals(rev, StringComparison.OrdinalIgnoreCase);
        //         if (palindrom == true)
        //         {
        //             Console.WriteLine("Yes");
        //         } else
        //         {
        //             Console.WriteLine("No");
        //         }
        //     }
        // }

        // class numberFive 
        // {
        //     public static string Random()
        //     {
        //         var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        //         var s = new char[];
        //         var random = new Random();

        //         for (int i=0; i<s.Length; i++){
        //             s[i] = chars[random.Next(chars.Length)];
        //         }

        //         var result = new String(s);
        //     }
        // }

        // class numberSix
        // {
            
        // }
    }
}
