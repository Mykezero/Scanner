﻿// Author: Myrmidon
// Site: FFEVO.net
// All credit to him!
// http://www.ffevo.net/topic/2726-autodetecting-characters-logged-in-out-for-multiboxers/

using System.Diagnostics;
using FFACETools;

namespace Vivisection
{
    public class FFInstance
    {
        public Process MyProcess { get; private set; }
        public FFACE Instance { get; private set; }

        #region Constructor
        public FFInstance(Process proc)
        {
            MyProcess = proc;
            Instance = new FFACE(MyProcess.Id);
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            if (!Valid) { return "DELETED"; }
            else { return MyProcess.MainWindowTitle; }
        }
        #endregion

        #region Valid Check
        public bool Valid
        {
            get
            {
                return (MyProcess == null ? false : !MyProcess.HasExited);
            }
        }
        #endregion

        #region Equals Override
        public override bool Equals(object obj)
        {
            FFInstance temp = obj as FFInstance;
            if (temp == null) { return false; }
            return MyProcess.Id == temp.MyProcess.Id;
        }

        public override int GetHashCode() { return base.GetHashCode(); }
        #endregion
    }
}