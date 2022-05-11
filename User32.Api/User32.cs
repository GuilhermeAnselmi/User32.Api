using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static User32.Api.Program;

namespace User32.Api
{
    internal class User32
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int message(int hWnd, String text, String caption, uint type);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out CursorPosition lpPoint);

        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern Int16 GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern bool SendInput(uint xInputs, Structs.INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        public static extern bool GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
    }
}
