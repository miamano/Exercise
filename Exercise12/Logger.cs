﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12
{
    class Logger : ILogger
    {
        public List<string> LogPosts { get; private set; }

        public Logger()
        {
            LogPosts = new List<string>();
        }

        public void Log(string message)
        {
            LogPosts.Add(message);
        }
    }
}
