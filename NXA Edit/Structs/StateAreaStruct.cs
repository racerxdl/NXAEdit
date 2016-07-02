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
  [StructLayout(LayoutKind.Sequential, Size = 30692), Serializable]
  public struct StateAreaStruct {
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] crc;
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64)]
    public byte[] usbserial;
    public short year;
    public byte month;
    public byte day;
    public byte hour;
    public byte min;
    public short seconds;               // Value / 1000
    public int avatarid;
    public int rank;
    public int countryid;
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] playerid;             //  player name
    public int mileage;                 //  Mileage
    public int playcount;
    public int kcal;
    public int vo2;
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] worldmaxmappos;
    public float reward;                //  (value * 100) / 65 = Reward %
    public float worldmax;              //  (value * 100) / 634 = Worldmax %
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9628)]
    public byte[] unusedspace1;           //  Size 9631 bytes
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] currentland;
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] currentmission;
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1280)]
    public WorldMaxScoreTableStruct[] worldmaxscoretable;
    public int dongleid;
    public int unlocksignal;
    public int steps;
    public float playtime;              //  minutes
    public float totalcomplete;         //  %
    public float arcadecomplete;        //  %
    public float brainshowercomplete;   //  %
    public float specialcomplete;       //  %
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4096)]
    public byte[] unusedspace2;
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 576)]
    public byte[] songlocks;            //  0x40 Unlock the song
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 36)]
    public byte[] unusedspace3;
  }
}
