using System.Drawing;
using System.Runtime.InteropServices;

namespace User32.Api;

internal class Program
{
    public const int MOD_ALT = 0x0001;
    public const int MOD_WIN = 0x0008;
    public const int MOD_CONTROL = 0x0002;
    public const int MOD_SHIFT = 0x004;
    public const int MOD_NOREPEAT = 0x400;
    public const int WM_HOTKEY = 0x312;
    public const int DSIX = 0x36;

    public const int KEYEVENF_KEYUP = 0x0002;

    [Flags]
    public enum MouseEventType
    {
        LEFTDOWN = 0x00000002,
        LEFTUP = 0x00000004,
        MIDDLEDOWN = 0x00000020,
        MIDDLEUP = 0x00000040,
        MOVE = 0x00000001,
        ABSOLUTE = 0x00008000,
        RIGHTDOWN = 0x00000008,
        RIGHTUP = 0x00000010,
    }

    static void Main(string[] args)
    {
        
        LeftClick();        //Left Click
        RightClick();       //Right Click
        DoubleClick();      //Double Left Click

        User32.message(0, "Trabalhando com código nativo em C#", "Interoperabilidade", 0);     //Send Message in Window

        var t = GetCursorPosition();    //Get Cursor Position

        User32.SetCursorPos(500, 500);         //Move Cursor

        //Read Key Press
        while (false)
        {
            for (int key = 0; key < 255; key++)
            {
                //caso seja diferente da tecla pressionada, irá retornar zero
                if (User32.GetAsyncKeyState(key) == -32767)
                {
                    char keyPress = Convert.ToChar(key);
                }
            }
        }

        //NICE!!!
        //Verify Key Press
        var k = User32.GetKeyState(74);

        Console.WriteLine(k);
        Console.ReadLine();

        //NICE!!!!!
        //Simuleta Keyboard
        User32.keybd_event(0x10, 0, 0, UIntPtr.Zero);
        User32.keybd_event(0x55, 0, 0, UIntPtr.Zero);
        User32.keybd_event(0x55, 0, KEYEVENF_KEYUP, UIntPtr.Zero);
        User32.keybd_event(0x10, 0, KEYEVENF_KEYUP, UIntPtr.Zero);

        //
        //   KEYEVENF_KEYUP  //Insert if for up key
        //   0               //No insert KEYEVENF_KEYUP if for down key
        //
        




        ////FAIL
        //INPUT[] input = new INPUT[2];
        //
        //input[0].type = 1;         //Simulate Keyboard
        //
        //input[0].ki.wVk = 16;      //Shift Key
        //
        //input[0].ki.dwFlags = 0;   //Press
        ////input.ki.dwFlags = 2;   //Lift
        ////input.ki.dwFlags = 4;   //Enter UNICODE characters
        //
        //input[0].type = 1;
        //input[0].ki.wVk = 16;
        //input[0].ki.dwFlags = 0;
        //
        //input[1].type = 1;
        //input[1].ki.wVk = 74;
        //input[1].ki.dwFlags = 0;
        //
        //SendInput(1u, input, Marshal.SizeOf((object)default(INPUT)));
        


    }

    public static void LeftClick()
    {
        User32.mouse_event((int)(MouseEventType.LEFTDOWN), 0, 0, 0, 0);
        User32.mouse_event((int)(MouseEventType.LEFTUP), 0, 0, 0, 0);
    }

    public static void RightClick()
    {
        User32.mouse_event((int)(MouseEventType.RIGHTDOWN), 0, 0, 0, 0);
        User32.mouse_event((int)(MouseEventType.RIGHTUP), 0, 0, 0, 0);
    }

    public static void DoubleClick()
    {
        User32.mouse_event((int)(MouseEventType.LEFTDOWN), 0, 0, 0, 0);
        User32.mouse_event((int)(MouseEventType.LEFTUP), 0, 0, 0, 0);
        User32.mouse_event((int)(MouseEventType.LEFTDOWN), 0, 0, 0, 0);
        User32.mouse_event((int)(MouseEventType.LEFTUP), 0, 0, 0, 0);
    }

    public static Point GetCursorPosition()
    {
        CursorPosition lpPoint;
        User32.GetCursorPos(out lpPoint);

        return lpPoint;
    }

    public struct CursorPosition
    {
        public int X;
        public int Y;

        public static implicit operator Point(CursorPosition point)
        {
            return new Point(point.X, point.Y);
        }
    }
}