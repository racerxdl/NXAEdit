﻿// ---------------------------------------------------------------------------
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
using System.Text;

public static class Extensions {
  public static T[] SubArray<T>(this T[] data, int index, int length) {
    T[] result = new T[length];
    Array.Copy(data, index, result, 0, length);
    return result;
  }
  public static byte[] ToUTF8ByteArray(this String str, int length) {
    byte[] arr = new byte[length];
    byte[] strArrEncoding = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(str));

    for (int i = 0; i < length; i++) {
      arr[i] = i < strArrEncoding.Length ? strArrEncoding[i] : (byte)0x00;
    }

    return arr;
  }

  public static byte[] ToUTF8ByteArray(this String str) {
    return Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(str));
  }

  public static string ToStringFromUTF8(this byte[] bytes) {
    return Encoding.UTF8.GetString(bytes).Split('\0')[0];
  }
  public static UInt32 ReverseBytes(this UInt32 value) {
    return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
           (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
  }

}