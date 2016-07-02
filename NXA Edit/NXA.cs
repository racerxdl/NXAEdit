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

using System.Runtime.InteropServices;
using NXA_Edit.Structs;

namespace NXA_Edit {
  /// <summary>
  /// NXA Save Structures
  /// </summary>
  class NXA {
    private ReviewAreaStruct reviewArea;
    private StateAreaStruct stateArea;

    public NXA() {

    }
    public NXA(byte[] data) {
      LoadFromBuffer(data);
    }
    public void LoadFromBuffer(byte[] data) {
      byte[] buff = new byte[Marshal.SizeOf(typeof(ReviewAreaStruct))];
      int amt = 0;
      while (amt < buff.Length) {
        buff[amt] = data[amt];
        amt++;
      }
      GCHandle handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
      reviewArea = (ReviewAreaStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(ReviewAreaStruct));
      handle.Free();
      //buff = new byte[Marshal.SizeOf(typeof(StateAreaStruct)];

      buff = data.SubArray(0x144, Marshal.SizeOf(typeof(StateAreaStruct)));
      Tools.Decode(buff);

      handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
      stateArea = (StateAreaStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(StateAreaStruct));
      handle.Free();
    }

    public ReviewAreaStruct ReviewArea {
      get { return reviewArea; }
      set { reviewArea = value; }
    }

    public StateAreaStruct StateArea {
      get { return stateArea; }
      set { stateArea = value; }
    }

    public string CurrentLand {
      get { return stateArea.currentland.ToStringFromUTF8(); }
      set { stateArea.currentland = value.ToUTF8ByteArray(128); }
    }

    public string PlayerID {
      get { return reviewArea.playerid.ToStringFromUTF8(); }
      set { reviewArea.playerid = value.ToUTF8ByteArray(8); }
    }
  }
}
