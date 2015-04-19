﻿
/*///////////////////////////////////////////////////////////////////
<ZScanLib, a small library for reading and working with memory.>
Copyright (C) <2014>  <Zerolimits>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
*/
///////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZScanLib
{
    /// <summary>
    /// Retrieves system address information. 
    /// </summary>
    internal class AddressInfo
    {
        /// <summary>
        /// The system's info that contains the max and memory 
        /// address space addresses. 
        /// </summary>
        private static WinAPI.SYSTEM_INFO _systemInfo;

        static AddressInfo()
        {
            WinAPI.GetSystemInfo(ref _systemInfo);
        }

        /// <summary>
        /// The minimum memory address. 
        /// </summary>
        public static long MinimumAddress
        {
            get
            {
                return (long)_systemInfo.lpMinimumApplicationAddress;
            }
        }

        /// <summary>
        /// The max memory address. 
        /// </summary>
        public static long MaximumAddress
        {
            get
            {
                return (long)_systemInfo.lpMaximumApplicationAddress;
            }
        }
    }
}
