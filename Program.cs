using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

    const uint MOUSEEVENTF_MOVE = 0x0001;

    static Random random = new Random();

    static void Main()
    {
        Console.WriteLine("Activity With Randomness Started ....");

        while (true)
        {
            SimulateActivity();

            int waitTime = random.Next(1000, 5000); // Random wait time between 1 and 5 seconds
            Console.WriteLine($"Waiting for {waitTime} milliseconds...");

            Thread.Sleep(waitTime);
        }

        static void SimulateActivity()
        {
            // Move the mouse to a random position on the screen
            int x = random.Next(-2, 3);
            int y = random.Next(-2, 3);

            mouse_event(MOUSEEVENTF_MOVE, (uint)x, (uint)y, 0, 0);
            Console.WriteLine($"Simulated moved to ({x}, {y}) at {DateTime.Now}");
        }
    }
}