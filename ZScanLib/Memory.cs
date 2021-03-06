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

/**
 * Clipper (c) atom0s 2004 - 2013 [wiccaan@comcast.net]
 * ---------------------------------------------------------------------------------
 * This file is part of Clipper.
 *
 *      Clipper is free software: you can redistribute it and/or modify
 *      it under the terms of the GNU Lesser General Public License as published by
 *      the Free Software Foundation, either version 3 of the License, or
 *      (at your option) any later version.
 *
 *      Clipper is distributed in the hope that it will be useful,
 *      but WITHOUT ANY WARRANTY; without even the implied warranty of
 *      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *      GNU Lesser General Public License for more details.
 *
 *      You should have received a copy of the GNU Lesser General Public License
 *      along with Clipper.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace ZScanLib
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Memory Helper Class
    /// 
    /// Wraps ReadProcessMemory and WriteProcessMemory API for easier usage.
    /// </summary>
    public class Memory
    {
        /// <summary>
        /// Reads the amount of bytes from the given location.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="lpAddress"></param>
        /// <param name="btBuffer"></param>
        /// <returns></returns>
        public static bool Peek(Process process, IntPtr lpAddress, byte[] btBuffer)
        {
            if (process == null) throw new ArgumentNullException("process");
            if (btBuffer == null) throw new ArgumentNullException("btBuffer");
            if (btBuffer.Length == 0) throw new ArgumentException("btBuffer");

            var read = new IntPtr(0);
            return WinAPI.ReadProcessMemory(process.Handle, lpAddress, btBuffer, (uint)btBuffer.Length, ref read);
        }

        /// <summary>
        /// Writes the given bytes to the given memory location.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="lpAddress"></param>
        /// <param name="btBuffer"></param>
        /// <returns></returns>
        public static bool Poke(Process process, IntPtr lpAddress, byte[] btBuffer)
        {
            if (process == null) throw new ArgumentNullException("process");
            if (btBuffer == null) throw new ArgumentNullException("btBuffer");
            if (btBuffer.Length == 0) throw new ArgumentException("btBuffer");

            var written = new IntPtr(0);
            return WinAPI.WriteProcessMemory(process.Handle, lpAddress, btBuffer, (uint)btBuffer.Length, ref written);
        }
    }
}