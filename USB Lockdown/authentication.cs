using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace USB_Lockdown
{
    class authentication
    {
        internal static Thread authenticationThread;
        internal static Thread deviceScanner;
        internal static void startScanning()
        {
            Thread authenticationThread = new Thread(beginAuthentication);
        }

        internal static void beginAuthentication()
        {
            Thread deviceScanner = new Thread(deviceScan.scanDevices);
            deviceScanner.Join(); //the thread will exit when a valid drive has been found

            //code here to unlock computer and 
        }
    }
    class deviceScan
    {
        internal static DriveInfo validDrive;
        internal static DriveInfo[] driveListing;
        private static bool driveFound = false;


        internal static void scanDevices()
        {
            while (!driveFound) {
                driveListing = DriveInfo.GetDrives();
                foreach (DriveInfo currentDrive in driveListing)
                {
                    if (File.Exists(currentDrive.Name + "\\LockDown.config")) // the first check for a valid drive. Could be something else, but this is a lightweight test to be done first!
                    {
                        if (driveValidate(currentDrive)) //runs the full validation of the drive
                        {
                            validDrive = currentDrive;
                            driveFound = true;
                            break;
                        }
                    }
                }
            }
        }

        internal static bool driveValidate(DriveInfo drive){

            return true;
        }

        internal static void resetValues()
        {
            validDrive = null;
            driveListing = null;
            driveFound = false;
        }
    }
}
