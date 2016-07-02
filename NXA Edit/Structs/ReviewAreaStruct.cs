// ---------------------------------------------------------------------------
//    NX2 / NXA Save Game Editor
//    Copyright (C) 2015  Lucas Teske
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
// ---------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace NXA_Edit.Structs {
  [StructLayout(LayoutKind.Sequential, Size = 324), Serializable]
  public struct ReviewAreaStruct {
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] playerid;             //  player name
    public int mileage;                 //  Mileage
    public float reward;                //  (value * 100) / 65 = Reward %
    public float worldmax;              //  (value * 100) / 634 = Worldmax %
    public int playcount;
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] currentland;
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] currentmission;
    public int kcal;
    public int vo2;
    public short year;
    public byte month;
    public byte day;
    public byte hour;
    public byte min;
    public short seconds;               // Value / 1000
    public int steps;
    public float playtime;              //  minutes
    public float totalcomplete;         //  %
    public float arcadecomplete;        //  %
    public float brainshowercomplete;   //  %
    public float specialcomplete;       //  %
  }
}
