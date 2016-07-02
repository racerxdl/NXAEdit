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
using System.Management;

namespace NXA_Edit {
  /// <summary>
  /// Class describing connected USB Drives
  /// </summary>
  class USBDrive {
    private double size;
    private string deviceID, model, serialNumber;

    public USBDrive(ManagementObject usbDrive) {
      this.deviceID = usbDrive["DeviceID"].ToString();
      this.model = usbDrive["Model"].ToString();
      this.serialNumber = usbDrive["SerialNumber"].ToString();
      this.size = Math.Round(double.Parse(usbDrive["Size"].ToString()) / (1024 * 1024 * 1024), 2); // Convert bytes to GB
    }
    public USBDrive(string DeviceID, string Model, string SerialNumber, double size) {
      this.deviceID = DeviceID;
      this.model = Model;
      this.serialNumber = SerialNumber;
      this.size = size;
    }

    public string DeviceID {
      get { return deviceID; }
    }

    public string Model {
      get { return model; }
    }

    public string SerialNumber {
      get { return serialNumber; }
    }

    public double Size {
      get { return size; }
    }

    override public string ToString() {
      return "DeviceID: " + this.DeviceID + " - Model: " + this.Model + " - SerialNumber: " + this.SerialNumber + " Size: " + this.size + " GB";
    }
    public string ToSimpleString() {
      return this.Model + " - (" + this.size + " GB)";
    }
  }
}
