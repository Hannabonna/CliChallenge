using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Collections.Generic;
using McMaster.Extensions.CommandLineUtils;
using System.Globalization;
using System.Linq;

namespace cli_Challenge
{
    [HelpOption("--hlp")]
    [Subcommand(
  
        typeof(UpperCase),
        typeof(LowerCase),
        typeof(Capital),
       
        typeof(Add),
        typeof(Subtract),
        typeof(Multiply),
        typeof(Divide),
      
        typeof(Palindrome),
      
        typeof(Obfuscator),
        
        //typeof(Random),
       
        typeof(IpAddress),
        
        typeof(IpExternal)
        //no8
        //no9
        //no10
    )]
    class Program
    {
        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }

        //numberOne
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
        [Command(Description = "Command to capitalize string", Name = "capitalize")]
        class Capital
        {
            [Argument(0)]
            public string text { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                Console.WriteLine($"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text)}");
            }
        }

        //numberTwo
        [Command(Description = "Command to add", Name = "add")]
        class Add
        {
            [Argument(0)]
            public int[] number { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                int result =0;

                for (int i = 0; i < number.Length; i++)
                {
                    result += number[i];
                }
                Console.WriteLine(result);
            }
        }
        [Command(Description = "Command to subtract", Name = "subtract")]
        class Subtract
        {
            [Argument(0)]
            public int[] number { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                int result =0;

                for (int i = 0; i < number.Length; i++)
                {
                    result -= number[i];
                }
                Console.WriteLine(result);
            }
        }
        [Command(Description = "Command to multiply", Name = "multiply")]
        class Multiply
        {
            [Argument(0)]
            public int[] number { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                int result =0;

                for (int i=1; i < number.Length; i++)
                {
                    result *= number[i];
                }
                Console.WriteLine(result);
            }
        }
        [Command(Description = "Command to divide", Name = "divide")]
        class Divide
        {
            [Argument(0)]
            public int[] number { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                int result =0;

                for (int i=1; i < number.Length; i++)
                {
                    result /= number[i];
                }
                Console.WriteLine(result);
            }
        }

        //numberThree
        [Command(Description = "Command to palindrome", Name = "palindrome")]
        class Palindrome
        {
            [Argument(0)]
            public string text { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                string rev;
                char[] word = text.ToCharArray();
                Array.Reverse(word);

                rev = new string(word);
                bool palindrom = text.Equals(rev, StringComparison.OrdinalIgnoreCase);
                if (palindrom == true)
                {
                    Console.WriteLine("Is palindrome? Yes");
                } else
                {
                    Console.WriteLine("Is palindrome? No");
                }
            }
        }

        //numberFour
        [Command(Description = "Command to obfuscator", Name = "obfuscator")]
        class Obfuscator
        {
            [Argument(0)]
            public string text { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                char[] b = text.ToCharArray();
                List<string> c = new List<string>();

                for(int d = 0 ; d < text.Length - 1; d++)
                {
                    var e = Convert.ToInt32(text[d]);
                    e.ToString();
                    c.Add($"&#{e}");
                }

                Console.WriteLine(String.Join(";", c));
            }
        }

        // numberFive
        // [Command(Description = "Command to random string", Name = "random")]
        // class Random
        // {
        //     [Argument(0)]
        //     public string text { get; set; }

        //     public void OnExecute(CommandLineApplication app)
        //     {
        //         int n = 32;
        //         var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        //         var ran = new char[n];
        //         Random r = new Random();

        //         for (int i=0; i<ran.Length; i++){
        //             ran[i] = chars[r.Next];
        //         }

        //         var result = new String(ran);
        //     }
        // }

        //numberSix
        [Command(Description = "Command to ip address", Name = "ip")]
        class IpAddress
        {
            public void OnExecute(CommandLineApplication app)
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostEntry(host).AddressList[3].ToString();

                Console.WriteLine(ip);
            }
        }

        //numberSeven
        [Command(Description = "Command to ip external", Name = "ip-external")]
        class IpExternal
        {
            public void OnExecute(CommandLineApplication app)
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    Console.WriteLine("null");
                }
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                Console.WriteLine(host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)); 
            }
        }



    }
}
