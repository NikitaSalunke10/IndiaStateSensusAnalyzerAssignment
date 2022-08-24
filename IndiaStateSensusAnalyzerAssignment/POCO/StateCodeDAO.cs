﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaStateSensusAnalyzerAssignment.POCO
{
    public class StateCodeDAO //this class is used to assign the values through constructor
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;
        public StateCodeDAO(string v1, string v2, string v3, string v4)
        {
            this.serialNumber = Convert.ToInt32(v1);
            this.stateName = v2;
            this.tin = Convert.ToInt32(v3);
            this.stateCode = v4;
        }
    }
}
