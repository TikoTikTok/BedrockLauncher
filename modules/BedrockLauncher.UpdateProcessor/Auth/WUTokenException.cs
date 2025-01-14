﻿using System;
using System.Runtime.InteropServices;

namespace BedrockLauncher.UpdateProcessor.Auth
{
    public class WUTokenException : Exception
    {
        public const int WU_ERRORS_START = 0x7ffc0200;
        public const int WU_NO_ACCOUNT = 0x7ffc0200;
        public const int WU_ERRORS_END = 0x7ffc0200;

        public WUTokenException(int exception) : base(GetExceptionText(exception))
        {
            HResult = exception;
        }
        private static String GetExceptionText(int e)
        {
            switch (e)
            {
                case WU_NO_ACCOUNT: return "No account";
                default: return "Unknown " + e;
            }
        }

        public static void Test(int status)
        {
            if (status >= WUTokenException.WU_ERRORS_START && status <= WUTokenException.WU_ERRORS_END) throw new WUTokenException(status);
            else if (status != 0) Marshal.ThrowExceptionForHR(status);
        }
    }

}
