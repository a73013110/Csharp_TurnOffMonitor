using System;
using System.Runtime.InteropServices;

namespace Csharp_TurnOffMonitor
{
    /// <summary>
    /// Define DllImport and some parameters
    /// </summary>
    public partial class TurnOffMonitor
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public static readonly IntPtr HWND_BROADCAST = new IntPtr(0xffff);
        public static readonly int WM_SYSCOMMAND = 0x0112;
        public static readonly IntPtr SC_MONITORPOWER = new IntPtr(0xf170);
        public static readonly IntPtr MONITOR_SHUT_OFF = new IntPtr(2);
    }
}
