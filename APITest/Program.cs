﻿using Pixeez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static APITest.SensitiveData;

namespace APITest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await Program.PixivDemo()).Wait();
        }
        static async Task PixivDemo()
        {
            var tokens = await Auth.AuthorizeAsync(username, passwd);
            Console.WriteLine(tokens.Tokens.AccessToken);
            var follow = await tokens.Tokens.GetMyFollowingWorksAsync();
            Console.WriteLine((await tokens.Tokens.GetMyFavoriteWorksAsync()).Count);
            Console.ReadKey();
        }

    }
}