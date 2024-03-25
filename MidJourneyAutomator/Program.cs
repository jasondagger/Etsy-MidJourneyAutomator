using System.Diagnostics;
using System.Runtime.InteropServices;

public static partial class Program
{
    [DllImport("user32.dll")]
    private static extern int SetForegroundWindow(IntPtr hWnd);

    [STAThread]
    private static void Main()
    {
        string[] subjects =
        {
            "giraffe",
            "elephant",
            "lion",
            "turtle",
        };

        int count = 1;
        int index = 0;
        while (true)
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] discordProcesses = Process.GetProcessesByName(
                "Discord"
            );

            foreach (Process process in discordProcesses)
            {
                SetForegroundWindow(process.MainWindowHandle);

                string prompt = $"/imagine prompt:" +
                                $"happy tiny cute cartoon {subjects[index]} peeking from the center bottom of the image," +
                                $"cute,rare,cartoon,cel shaded,simple,solid color background,2d,16k,lsd --ar 3:5 --tile";

                Clipboard.SetText(prompt);
                SendKeys.SendWait("^(v)");
                SendKeys.SendWait("{ENTER}");
            }

            SetForegroundWindow(currentProcess.MainWindowHandle);
            Console.WriteLine(
                $"Iteration {count++}: {subjects[index]}"
            );

            index++;
            if (index == subjects.Length)
            {
                index = 0;
            }

            Thread.Sleep(210000);
        }
    }
}