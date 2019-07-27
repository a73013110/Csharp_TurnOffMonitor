using Csharp_HUD;
using System.Threading;
using System.Windows;

namespace Csharp_TurnOffMonitor
{
    public partial class TurnOffMonitor
    {
        public static void Main(string[] args)
        {
            #region Create Application and Thread
            Application app = null;    // We need a application to new a HUD window   
            // Use another thread to run the application
            Thread hudThread = new Thread(new ThreadStart(() =>
            {
                app = new Application
                {
                    ShutdownMode = ShutdownMode.OnExplicitShutdown
                };
                app.Run();
            }));
            hudThread.SetApartmentState(ApartmentState.STA);    // Set the thread to run in single thread apartment
            hudThread.Start();
            #endregion

            SpinWait.SpinUntil(() => (app != null));  // Wait until the app is created

            #region Start duration and ShutOffMonitor after that
            const int DURATION = 3;   // Set HUD display duration(second)
            app.Dispatcher.Invoke(() =>
            {
                HUD hud = new HUD();    // New HUD window
                _ = AccordingTimeToChangeValue(hud, DURATION);  // Change some message on the HUD
                hud.Show();
                hud.StartDuration();    // Start HUD animation
                _ = DurationCompletedEventHandler(app, hud);    // ShutOffMonitor after duration
            });
            #endregion
        }
    }
}
