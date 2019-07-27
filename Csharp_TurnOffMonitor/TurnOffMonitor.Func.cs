using Csharp_HUD;
using System.Threading.Tasks;
using System.Windows;

namespace Csharp_TurnOffMonitor
{
    public partial class TurnOffMonitor
    {
        /// <summary>
        /// Change title and message according time
        /// </summary>
        private static async Task AccordingTimeToChangeValue(HUD hud, int duration)
        {
            string[] msgTitle = { "螢幕即將關閉", "螢幕即將關閉", "螢幕即將關閉" };
            string[] msgDetail = { "剩餘3秒", "剩餘2秒", "剩餘1秒" };
            hud.Message.MsgDuration = duration;
            for (int i = 0; i < duration; i++)
            {
                hud.SetMsg(msgTitle[i], msgDetail[i]);
                await Task.Delay(1000);
            }
        }

        private static async Task DurationCompletedEventHandler(Application app, HUD hud)
        {
            while (!hud.Message.IsMsgDurationCompleted)
            {
                await Task.Delay(1000);
            }
            app.Shutdown();
            ShutOffMonitor();
        }

        /// <summary>
        /// Turn off the monitor
        /// </summary>
        public static void ShutOffMonitor()
        {
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_SHUT_OFF);
        }
    }
}
