using System.Diagnostics;
using System.Runtime.InteropServices;

public static partial class Program
{
    [DllImport("user32.dll")]
    private static extern int SetForegroundWindow(
        IntPtr hWnd
    );

    [STAThread]
    private static void Main()
    {
        string[] prompts = {
            "cartoon pineapple sprite sheet pattern, elegant, cute, boho, ombre, rare, legendary, professional, simple, 2d, lsd, ux, hlsl, rule34, hdr, hd --no eyes,hands,mouths,ears,faces,fingers",
            "cartoon coconut sprite sheet pattern, elegant, cute, boho, ombre, rare, legendary, professional, simple, 2d, lsd, ux, hlsl, rule34, hdr, hd --no eyes,hands,mouths,ears,faces,fingers",
            "cartoon pomegranate sprite sheet pattern, elegant, cute, boho, ombre, rare, legendary, professional, simple, 2d, lsd, ux, hlsl, rule34, hdr, hd --no eyes,hands,mouths,ears,faces,fingers",
            "cartoon mango sprite sheet pattern, elegant, cute, boho, ombre, rare, legendary, professional, simple, 2d, lsd, ux, hlsl, rule34, hdr, hd --no eyes,hands,mouths,ears,faces,fingers",
            "cartoon kiwi sprite sheet pattern, elegant, cute, boho, ombre, rare, legendary, professional, simple, 2d, lsd, ux, hlsl, rule34, hdr, hd --no eyes,hands,mouths,ears,faces,fingers",
        };

        int count = 1;
        int index = 0;
        int iteration = 0;
        const int maxIterations = 5;
        while (true)
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] discordProcesses = Process.GetProcessesByName(
                "Discord"
            );

            foreach (Process process in discordProcesses)
            {
                SetForegroundWindow(
                    process.MainWindowHandle
                );
                Clipboard.SetText(
                    $"/imagine prompt:" +
                    $"{prompts[index]}" +
                    $" --ar 3:5"
                );
                SendKeys.SendWait(
                    "^(v)"
                );
                SendKeys.SendWait(
                    "{ENTER}"
                );
            }

            SetForegroundWindow(
                currentProcess.MainWindowHandle
            );

            Console.WriteLine(
                $"Total Cycles: {count++}"
            );
            if (++iteration > maxIterations)
            {
                iteration = 0;
                index++;
                if (index == prompts.Length)
                {
                    index = 0;
                }
            }

            Thread.Sleep(150000);
        }
    }
}