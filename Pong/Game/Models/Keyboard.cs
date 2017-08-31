using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pong.Game.Models
{
    public static class Keyboard
    {
        public static bool Up => System.Windows.Input.Keyboard.IsKeyDown(Key.Up);
        public static bool Down => System.Windows.Input.Keyboard.IsKeyDown(Key.Down);
        public static bool X => System.Windows.Input.Keyboard.IsKeyDown(Key.X);
        public static bool S => System.Windows.Input.Keyboard.IsKeyDown(Key.S);
    }
}
